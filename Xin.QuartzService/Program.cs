using log4net;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using System;
using System.IO;
using Xin.Common;
using Xin.ExternalService.EC.Job;
using Xin.ExternalService.EC.Job.Daily;

namespace XIn.QuartzService
{
    public class Program
    {

        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var repository = LogManager.CreateRepository(LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            StdSchedulerFactory factory = new StdSchedulerFactory();
            var _scheduler = await factory.GetScheduler();
            await _scheduler.Start();
            string quartzStartTime = "0 0 9 * * ? *";
            #region EcSaleOrderDaily
            IJobDetail job = JobBuilder.Create<EcSaleOrderDaily>()
                .WithIdentity("job1", "group1")
                .Build();
            //创建触发器
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithCronSchedule(quartzStartTime)//每日3点开始执行
                .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
            #endregion

            #region EcGetSkuRelationDaily
            job = JobBuilder.Create<EcGetSkuRelationDaily>()
                  .WithIdentity("job2", "group1")
                  .Build();
            //创建触发器
            trigger = TriggerBuilder.Create()
               .WithIdentity("trigger2", "group1")
               .StartNow()
               .WithCronSchedule(quartzStartTime)//每日3点开始执行
               .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
            #endregion

            #region EcGetRmaRefundDaily
            job = JobBuilder.Create<EcGetRmaRefundDaily>()
                  .WithIdentity("job3", "group1")
                  .Build();
            //创建触发器
            trigger = TriggerBuilder.Create()
               .WithIdentity("trigger3", "group1")
               .StartNow()
               .WithCronSchedule(quartzStartTime)//每日3点开始执行
               .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
            #endregion

            #region EcGetReceivingDetailDaily
            job = JobBuilder.Create<EcGetReceivingDetailDaily>()
                  .WithIdentity("job4", "group1")
                  .Build();
            //创建触发器
            trigger = TriggerBuilder.Create()
               .WithIdentity("trigger4", "group1")
               .StartNow()
               .WithCronSchedule(quartzStartTime)//每日3点开始执行
               .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);

            #endregion

            #region EcGetProductDaily
            job = JobBuilder.Create<EcGetProductDaily>()
                  .WithIdentity("job5", "group1")
                  .Build();
            //创建触发器
            trigger = TriggerBuilder.Create()
               .WithIdentity("trigger5", "group1")
               .StartNow()
               .WithCronSchedule(quartzStartTime)//每日3点开始执行
               .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
            #endregion

            #region EcGetDeliveryDetailDaily
            job = JobBuilder.Create<EcGetDeliveryDetailDaily>()
                  .WithIdentity("job6", "group1")
                  .Build();
            //创建触发器
            trigger = TriggerBuilder.Create()
               .WithIdentity("trigger6", "group1")
               .StartNow()
               .WithCronSchedule(quartzStartTime)//每日3点开始执行
               .Build();
            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
            #endregion

            Console.ReadKey();
        }
    }
}
