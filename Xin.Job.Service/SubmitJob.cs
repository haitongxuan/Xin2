using Quartz;
using Xin.Job.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Job.Server;

namespace Xin.Job.Service
{
    public class SubmitJobTask : IJob
    {
        public SubmitJobTask()
        {

        }
        public async Task Execute(IJobExecutionContext context)
        {
            var manage = new ScheduleManage();
            var schedule = new ScheduleEntity
            {
                JobGroup = context.JobDetail.Key.Group,
                JobName = context.JobDetail.Key.Name,
                RunStatus = EnumType.JobRunStatus.Running
            };
            manage.UpdateScheduleRunStatus(schedule);
            var model = manage.GetScheduleModel(context.JobDetail.Key.Group, context.JobDetail.Key.Name);
            await Console.Out.WriteLineAsync(string.Format("试一试:任务分组：{0}任务名称：{1}任务状态：{2}", schedule.JobGroup, schedule.JobName, schedule.RunStatus));
        }
    }
}
