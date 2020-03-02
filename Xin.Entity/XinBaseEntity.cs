using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities
{
    public class XinBaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("主键")]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("更新时间")]
        public virtual System.DateTime WriteDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("创建时间")]
        public virtual System.DateTime CreateDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("更新人")]
        public virtual int WriteUid
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("创建人")]
        public virtual int CreateUid
        {
            get;
            set;
        }

    }

    public class XinVDBaseEntity : XinBaseEntity
    {
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("是否删除")]
        public virtual bool StopFlag
        {
            get;
            set;
        }
    }
}
