using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xin.Job
{
    public abstract class BaseJob : IJob
    {
        protected DateTimeOffset? GetNextFireTime(DateTimeOffset? now, String cronExpression)
        {
            if (now.HasValue)
            {
                CronExpression cron = new CronExpression(cronExpression);
                var next = cron.GetNextValidTimeAfter(now.Value);
                return next;
            }
            else
            {
                return null;
            }
        }

        private DateTimeOffset? GetPreFireDate(DateTimeOffset? pre, DateTimeOffset now, String cronExpression)
        {
            if (DateTimeOffset.Compare(pre.Value, now) > 0)
            {
                return null;
            }
            var next = GetNextFireTime(pre, cronExpression);
            if (DateTimeOffset.Compare(next.Value, now) > 0)
            {
                return null;
            }
            while (next != null && DateTimeOffset.Compare(now, next.Value) > 0)
            {
                pre = next;
                next = GetPreFireDate(next, now, cronExpression);
            }
            return pre;
        }

        public DateTimeOffset? GetPreFireDate(String cronExpression)
        {
            int i = 0;
            DateTimeOffset now = DateTimeOffset.Now;
            DateTimeOffset? next = now;
            while (true)
            {
                i++;
                next = GetNextFireTime(next, cronExpression);
                long interval = next.Value.ToUnixTimeSeconds() - now.ToUnixTimeSeconds();
                DateTimeOffset? pre = now.AddSeconds(-interval);
                DateTimeOffset? result = GetPreFireDate(pre, now, cronExpression);//            System.out.println((result == null) + "\t下次执行时间:" + dsf.format(next) + "\t" + dsf.format(pre));
                if (i > 31 || result != null)
                {
                    if (result != null)
                    {

                        return result.Value.ToLocalTime();
                    }
                    break;
                }
            }
            return null;
        }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
