﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/6/3 15:50:40
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
    public partial class BnsAmazonReport {

        public BnsAmazonReport()
        {
            this.BnsAmazonReportDetails = new List<BnsAmazonReportDetail>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ReportRequestId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ReportType
        {
            get;
            set;
        }

        public virtual System.DateTime? CreateDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ReportId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Store
        {
            get;
            set;
        }

        public virtual System.DateTime? AvailableDate
        {
            get;
            set;
        }

        public virtual System.DateTime? EndDate
        {
            get;
            set;
        }

        public virtual System.DateTime? StartDate
        {
            get;
            set;
        }

        public virtual IList<BnsAmazonReportDetail> BnsAmazonReportDetails
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
