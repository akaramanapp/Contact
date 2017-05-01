using ContactApp.Entities.Concrete;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Web;

namespace ContactApp.Api.Infrastructure
{
    public static class Publisher
    {
        public static void SendMessage(ErrorLog log)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ErrorLog",
                                                         durable: false,
                                                         exclusive: false,
                                                         autoDelete: false,
                                                         arguments: null);

                    string _errorLog = JsonConvert.SerializeObject(log);
                    var body = Encoding.UTF8.GetBytes(_errorLog);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "ErrorLog",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine($" ErroCode: {log.ErrorCode} Platform:{log.Platform} [{log.ErrorText}]");
                }
            }
        }
    }
}