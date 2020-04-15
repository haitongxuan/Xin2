using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xin.Entities;
using Xin.Job.Model;

namespace Xin.Web.Framework.Helper
{
    public class QuartzHelper
    {
        public  static IScheduler _scheduler = new StdSchedulerFactory().GetScheduler().Result;
        public static async Task<BaseQuartzNetResult> addJobAsync(ResSchedule  resSchedule) {

            try
            {
                Assembly assembly = Assembly.Load(new AssemblyName(resSchedule.AssemblyName));
                Type type = assembly.GetType(resSchedule.ClassName);
                IJobDetail job = new JobDetailImpl(resSchedule.JobName, resSchedule.JobGroup, type);
                ITrigger trigger = TriggerBuilder.Create()
                       .WithIdentity(resSchedule.JobName, resSchedule.JobGroup)
                       .StartAt(resSchedule.BeginTime)
                       .EndAt(resSchedule.EndTime)
                       .WithCronSchedule(resSchedule.Cron)//指定cron表达式
                       .ForJob(resSchedule.JobName, resSchedule.JobGroup)
                       .Build();
                await _scheduler.ScheduleJob(job, trigger);
                return new BaseQuartzNetResult
                {
                    Code = 1000,
                    Msg = "启动成功"
                };
            }
            catch (Exception ex)
            {
                return new BaseQuartzNetResult
                {
                    Code = -1
                };
            }
        }

        public static async Task<BaseQuartzNetResult> StopScheduleAsync(ResSchedule resSchedule) {
            try
            {
                var jk = new JobKey(resSchedule.JobName, resSchedule.JobGroup);
                if (!await _scheduler.CheckExists(jk))
                {
                    return new BaseQuartzNetResult
                    {
                        Code = -1,
                        Msg = resSchedule.JobName + "任务未运行"
                    };
                }
                await QuartzHelper._scheduler.PauseJob(jk);
                return new BaseQuartzNetResult
                {
                    Code = 1000,
                    Msg = resSchedule.JobName + "停止任务成功"
                };
            }
            catch (Exception ex)
            {
                return new BaseQuartzNetResult
                {
                    Code = -1,
                    Msg = resSchedule.JobName + "停止任务失败"
                };
            }
        }


        public static async Task<BaseQuartzNetResult> ResumeScheduleAsync(ResSchedule resSchedule)
        {
            try
            {
                var jk = new JobKey(resSchedule.JobName, resSchedule.JobGroup);
                if (!await _scheduler.CheckExists(jk))
                {
                    return QuartzHelper.addJobAsync(resSchedule).Result;
                }
                await QuartzHelper._scheduler.ResumeJob(jk);
                return new BaseQuartzNetResult
                {
                    Code = 1000,
                    Msg = resSchedule.JobName + "重启任务成功"
                };
            }
            catch (Exception ex)
            {
                return new BaseQuartzNetResult
                {
                    Code = -1,
                    Msg = resSchedule.JobName + "重启任务失败"
                };
            }
        }
    }
}
