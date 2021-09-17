using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace DroneMaintenance.BLL.Services
{
    public class OrdersProducerService : IOrdersProducerService
    {
        private readonly IConfiguration _configuration;

        public OrdersProducerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PostSparePartOrder(OrderDto orderDto)
        {
            var factory = new ConnectionFactory() 
            {
                HostName = _configuration["RabbitMQ:hostName"], 
                Port = int.Parse(_configuration["RabbitMQ:port"]) 
            };
            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "orders", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(orderDto));

                channel.BasicPublish(exchange: "", routingKey: "orders", basicProperties: null, body: body);
            }
        }
    }
}
