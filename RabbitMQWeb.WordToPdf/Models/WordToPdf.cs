using Microsoft.AspNetCore.Http;

namespace RabbitMQWeb.WordToPdf.Models
{
    public class WordToPdf
    {
        public string Email { get; set; }
        public IFormFile WordFile { get; set; }
    }
}
