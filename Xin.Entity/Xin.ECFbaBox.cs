﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/7 14:11:12
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
    public partial class ECFbaBox {

        public ECFbaBox()
        {
            this.FinalBox = new List<ECFbaFinalBox>();
            this.OmsBox = new List<ECFbaOmsBox>();
            this.TransitBox = new List<ECFbaTransitBox>();
            OnCreated();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        public virtual int? OrderId
        {
            get;
            set;
        }

        public virtual ECFbaQueryOrder ECFbaQueryOrder
        {
            get;
            set;
        }

        public virtual IList<ECFbaFinalBox> FinalBox
        {
            get;
            set;
        }

        public virtual IList<ECFbaOmsBox> OmsBox
        {
            get;
            set;
        }

        public virtual IList<ECFbaTransitBox> TransitBox
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
