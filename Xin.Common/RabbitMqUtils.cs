using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Common
{
    public class RabbitMqUtils
    {
        public static void pushMessage(LogPushModel model)
        {
            var rbConfig = new AppConfigurationServices().Configuration;
            var factory = new ConnectionFactory() { HostName = rbConfig["RabbitMq:HostName"], UserName = rbConfig["RabbitMq:UserName"]
                , Password = rbConfig["RabbitMq:Password"], Port = int.Parse(rbConfig["RabbitMq:Port"]) };
            using (var connect = factory.CreateConnection())
            {
                using (var channel = connect.CreateModel())
                {
                    channel.QueueDeclare(
                                                  queue: rbConfig["RabbitMq:Queue"],
                                                  durable: true,
                                                  exclusive: false,
                                                  autoDelete: false,
                                                  arguments: null
                                                  );
                    string message = JsonConvert.SerializeObject(model);
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                    exchange: "",
                    routingKey: rbConfig["RabbitMq:Queue"],
                    basicProperties: properties,
                    body: body
                    );
                }
            }
        }
    }
}
