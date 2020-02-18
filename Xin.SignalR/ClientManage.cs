using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using Xin.Entities;
using Xin.Common;

namespace Xin.SignalR
{
    public class ClientManage
    {
        private readonly IUowProvider _uowProvider;

        public ClientManage(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        private string GetHubUrl()
        {
            AppConfigurationServices config = new AppConfigurationServices();
            return config.Configuration.GetSection("ChatHubUrl").Value;
        }

        public void ClientSend(int id)
        {
            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl(GetHubUrl())
                            .Build();
            //连接hub
            connection.StartAsync();
            Console.WriteLine("已连接");

            //定义一个客户端方法ReceiveMessage
            //connection.On<string, string>("ReceiveMessage", (UriParser, message) =>
            //{
            //    Console.WriteLine($"接收消息：{message}");
            //});
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var respository = uow.GetRepository<ResSchedule>();
                //根据任务编号获取任务详情
                var schedule = respository.Get(id);
                schedule.JobStatus = 0;
                schedule.WriteDate = DateTime.Now;
                respository.Update(schedule);
                uow.SaveChangesAsync();
            }
            //发送消息
            connection.InvokeAsync("SendMessage", "", "ok");
        }
    }
}
