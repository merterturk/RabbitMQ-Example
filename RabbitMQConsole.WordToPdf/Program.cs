using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Spire.Doc;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RabbitMQConsole.WordToPdf
{
    class Program
    {
        public static bool EmailSend(string email, MemoryStream memoryStream, string fileName)
        {
            try
            {
                memoryStream.Position = 0;
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);

                Attachment attach = new Attachment(memoryStream, ct);
                attach.ContentDisposition.FileName = $"{fileName}.pdf";

                MailMessage mailMessage = new MailMessage();

                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress("merterturk123@hotmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Pdf Dosyası oluşturma";
                mailMessage.Body = "Pdf dosyanız ektedir.";
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(attach);
                smtpClient.Host = "smtp.office365.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("merterturk123@hotmail.com", "******");
                smtpClient.Send(mailMessage);

                Console.WriteLine($"Sonuç:{email} adresine gönderilmiştir");
                memoryStream.Close();
                memoryStream.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mail gönderim sırasında bir hata meydana geldi:{ex.InnerException}");
                return false;
                throw;
            }

        }
        static void Main(string[] args)
        {
            bool result = false;
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yugpdoyf:vcuZkXb5vvX8fwUTHYKTalQhb5zgTFT3@toad.rmq.cloudamqp.com/yugpdoyf");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("convert-exchange", ExchangeType.Direct, true, false, null);

                    channel.QueueBind("File","convert-exchange","WordToPdf",null);

                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("File",false,consumer);

                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            Console.WriteLine("Kuyruktan bir mesaj alındı ve işleniyor");

                            Document document = new Document();
                            string deserializeString = Encoding.UTF8.GetString(ea.Body.ToArray());

                            MessageWordToPDF messageWordToPDF = JsonConvert.DeserializeObject<MessageWordToPDF>(deserializeString);

                            document.LoadFromStream(new MemoryStream(messageWordToPDF.WordByte),FileFormat.Docx2013);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                document.SaveToStream(ms, FileFormat.PDF);
                                result = EmailSend(messageWordToPDF.Email, ms, messageWordToPDF.FileName);
                            }
                            

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata meydana geldi:" + ex.Message);
                            throw;
                        }
                        if (result)
                        {
                            Console.WriteLine("Kuyruktan Mesaj başarıyla işlendi");
                            channel.BasicAck(ea.DeliveryTag, false);

                        }
                    };
                    Console.WriteLine("Çıkmak için tıklayınız");
                    Console.ReadLine();
                }
            }
        }
    }
}
