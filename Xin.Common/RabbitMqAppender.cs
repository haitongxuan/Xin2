using log4net.Appender;
using log4net.Core;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Xin.Common
{
    public class rabbitMqAppender: AppenderSkeleton
    {
        private string _HostName { get; set; }
        private string _UserName { get; set; }
        private string _Password { get; set; }
        private string _Queue { get; set; }
        private string _Vhost { get; set; }
        private int _Port { get; set; } = 5672;


        protected override void Append(LoggingEvent loggingEvent)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = _HostName, UserName = _UserName, Password = _Password, Port = _Port,VirtualHost= };
            using (var connect = factory.CreateConnection())
            {
                using (var channel = connect.CreateModel())
                {
                    channel.QueueDeclare(
                                                 queue: _Queue,
                                                 durable: true,
                                                 exclusive: false,
                                                 autoDelete: false,
                                                 arguments: null
                                                 );
                    string message = loggingEvent.RenderedMessage;
                    string leavel = loggingEvent.Level.Name;
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    var body = Encoding.UTF8.GetBytes( DateTime.Now.ToString()+' '+leavel+ ' '+message);
                    channel.BasicPublish(
                    exchange: "",
                    routingKey: _Queue,
                    basicProperties: properties,
                    body: body
                    );

                }
            }
        }
    }
}

