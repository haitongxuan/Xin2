using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Job.Model
{
    /// <summary>
	/// 枚举类型
	/// </summary>
	public class EnumType
    {
        public enum JobStatus
        {
            Started = 1,
            Stoped = 0
        }

        public enum JobStep
        {
            Completed = 1,
            Executeing = 2
        }

        public enum JobRunStatus
        {
            Running = 1,
            ToBeRun = 0
        }
    }
}
