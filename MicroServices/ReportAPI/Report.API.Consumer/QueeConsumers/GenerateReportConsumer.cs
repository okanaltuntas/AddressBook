using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.API.Services.Abstract;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Report.API.QueeConsumers
{
    public class GenerateReportConsumer : BackgroundService
    {
        private readonly ILocationReportService _locationReportService;
        readonly string _queueName = "generateReport";
        readonly string hostName = "localhost";


        public GenerateReportConsumer(ILocationReportService locationReportService)
        {
            _locationReportService = locationReportService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
               {
                   var body = ea.Body.ToArray();
                   var message = Encoding.UTF8.GetString(body);
                   Console.WriteLine(" [x] Received {0}", message);
                   var result = _locationReportService.GenerateLocationReport().GetAwaiter().GetResult();
                   Console.WriteLine(" [x] GenerateLocationReport Result {0} {1}", result, DateTime.Now);

               };
                channel.BasicConsume(queue: _queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();

            }
        }
    }
}
