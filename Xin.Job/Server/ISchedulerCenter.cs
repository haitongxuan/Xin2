using Quartz;
using System.Threading.Tasks;
using Xin.Job.Model;

namespace Xin.Job.Server
{
    public interface ISchedulerCenter
    {
        Task<BaseQuartzNetResult> ResumeJob(string jobName, string jobGroup);
        Task<BaseQuartzNetResult> RunScheduleJob<T, V>(string jobGroup, string jobName)
            where T : ScheduleManage, new()
            where V : IJob;
        Task<BaseQuartzNetResult> RunScheduleJob<T>(string jobGroup, string jobName) where T : ScheduleManage;
        void StopScheduleAsync();
        Task<BaseQuartzNetResult> StopScheduleJob<T>(string jobGroup, string jobName, bool isDelete = false) where T : ScheduleManage, new();
    }
}