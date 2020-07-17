using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Consumer.Domain;
using System;
using System.Text;
using System.Text.Json;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "registerUserQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var user = JsonSerializer.Deserialize<User>(message);

                Console.WriteLine($"User registered | " +
                    $"Id:{user.Id} | " +
                    $"Name:{user.Name} | " +
                    $"Email:{user.Email} | " +
                    $"Date created:{user.DateCreated} | " +
                    $"Date updated:{user.DateUpdated}");
            };
            channel.BasicConsume(queue: "registerUserQueue",
                                 autoAck: false,
                                 consumer: consumer);

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
