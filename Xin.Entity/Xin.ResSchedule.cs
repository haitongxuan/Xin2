﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/3/23 19:04:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace Xin.Entities
{
    public partial class ResSchedule : XinVDBaseEntity {

        public ResSchedule()
        {
            this.RunStatus = 0;
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("任务名称")]
        public virtual string JobName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("任务组")]
        public virtual string JobGroup
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("状态， 0 暂停任务；1 启用任务")]
        public virtual int JobStatus
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DisplayName("Cron表达式")]
        public virtual string Cron
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("任务所在DLL对应的程序集名称")]
        public virtual string AssemblyName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("任务所在类")]
        public virtual string ClassName
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("任务描述")]
        public virtual string Remark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("开始运行时间")]
        public virtual System.DateTime BeginTime
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("结束运行时间")]
        public virtual System.DateTime? EndTime
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("触发器类型（0、simple 1、cron）")]
        public virtual int TriggerType
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("执行间隔时间, 秒为单位")]
        public virtual int? IntervalSecond
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(300)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("job调用外部的url")]
        public virtual string Url
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("下次运行时间")]
        public virtual System.DateTime NextRunTime
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("上一次执行时间")]
        public virtual System.DateTime? LastRunTime
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("任务运行状态，Running=1，ToBeRun = 0")]
        public virtual int? RunStatus
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
