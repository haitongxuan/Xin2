using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xin.Entities;

namespace Xin.WebApi.Model
{
    public class UserModel
    {
        public UserModel()
        {
            this.RoleIds = new List<int>();
            this.PermissionIds = new List<int>();
        }
        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("用户名")]
        public virtual string UserName
        {
            get;
            set;
        }


        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DisplayName("真实名称")]
        public virtual string RealName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("用户密码")]
        public virtual string UserPwd
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("部门主键")]
        public virtual int DeptId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("停用标记")]
        public virtual bool StopFlag
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        [System.ComponentModel.DisplayName("管理员标记")]
        public virtual bool AdminFlag
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DisplayName("电话号码")]
        public virtual string Phone
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = @"Email is not a well-formed email address.")]
        [System.ComponentModel.DisplayName("电子邮箱")]
        public virtual string Email
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(512)]
        [System.ComponentModel.DisplayName("说明")]
        public virtual string Remark
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(512)]
        [System.ComponentModel.DisplayName("头像URL")]
        public virtual string HeadUrl
        {
            get;
            set;
        }

        [System.ComponentModel.DisplayName("登入时间")]
        public virtual System.DateTime LoginDate
        {
            get;
            set;
        }

        public new ResDepartment ResDepartment
        {
            get;
            set;
        }

        public virtual IList<int> RoleIds
        {
            get;
            set;
        }

        public virtual IList<int> PermissionIds
        {
            get;
            set;
        }
    }
}
