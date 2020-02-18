using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Job.Server;
using Xin.Repository;
using Xin.Entities;
using System.Linq;
using Xin.Common;
using Xin.Job.Model;

namespace Xin.WebApi.Extension
{
    public static class JobServiceExtensions
    {
        /// <summary>
        /// 程序启动将任务调度表里所有状态为 执行中 任务启动起来
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddJobService(this IServiceCollection serviceCollection)
        {
            serviceCollection.BuildServiceProvider().RegisterServiceProvider();
            var jobListner = ServiceCollectionExtension.Get<IJobListener>();
            var jobCenter = ServiceCollectionExtension.Get<ISchedulerCenter>();
            var uowProvider = ServiceCollectionExtension.Get<IUowProvider>();
            using (var uow = uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResSchedule>();
                var schedule = repository.Query(x => x.JobStatus.Equals(1));
                foreach (var item in schedule)
                {
                    if (!string.IsNullOrEmpty(item.Url))
                    {
                        item.AssemblyName = "Five.QuartzNetJob.ExecuteJobTask.Service";
                        item.ClassName = "HttpJobTask";
                    }
                    if (!string.IsNullOrEmpty(item.Url) || !string.IsNullOrEmpty(item.AssemblyName))
                    {
                        var scheduleEntity = DataMapper.MapperToModel(new ScheduleEntity(), item);
                        ScheduleManage.Instance.AddScheduleList(scheduleEntity);
                        var result = jobCenter.RunScheduleJob<ScheduleManage>(item.JobGroup, item.JobName).Result;
                    }

                }
            }
            return serviceCollection;
        }
    }
}
