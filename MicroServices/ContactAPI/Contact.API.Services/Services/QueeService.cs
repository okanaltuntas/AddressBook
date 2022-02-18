using Contact.API.Services.IServices;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.API.Services.Services
{
    public class QueeService : IQueeService
    {
        readonly string hostName = "localhost";
        readonly string _queueName = "generateReport";
        public void GenerateReport()
        {


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Report Create.";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

        }
    }
}
