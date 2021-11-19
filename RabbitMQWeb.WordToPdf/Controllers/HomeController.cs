using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQWeb.WordToPdf.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RabbitMQWeb.WordToPdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WordToPdfPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WordToPdfPage(WordToPdf.Models.WordToPdf wordtoPdf)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(Configuration.GetConnectionString("RabbitMQ"));

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("convert-exchange", ExchangeType.Direct, true, false, null);

                    channel.QueueDeclare(queue: "File", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    channel.QueueBind("File", "convert-exchange", "WordToPdf");

                    MessageWordToPdf messageWordToPdf = new MessageWordToPdf();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        wordtoPdf.WordFile.CopyTo(ms);
                        messageWordToPdf.WordByte = ms.ToArray();
                    }
                    messageWordToPdf.Email = wordtoPdf.Email;
                    messageWordToPdf.FileName = Path.GetFileNameWithoutExtension(wordtoPdf.WordFile.FileName);

                    string serializeMessage = JsonConvert.SerializeObject(messageWordToPdf);
                    byte[] ByteMessage = Encoding.UTF8.GetBytes(serializeMessage);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish("convert-exchange", "WordToPdf", basicProperties: properties, body: ByteMessage);

                    ViewBag.result = "Word dosyanız pdf dosyasına dönüştürüldükten sonra size email olarak gönderilecektir.";
                    return View();
                }
            }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
