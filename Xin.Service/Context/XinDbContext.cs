using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Xin.Entities;
using Xin.Common;
using Xin.Repository;
using Microsoft.Extensions.Configuration;

namespace Xin.Service.Context
{
    public partial class XinDBContext :  EntityContextBase<XinDBContext>
    {
        public XinDBContext() :
               base()
        {
            OnCreated();
        }

        public XinDBContext(DbContextOptions<XinDBContext> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(GetConnectionString("XinConnectionString"));
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            AppConfigurationServices config = new AppConfigurationServices();
            string connectinStr = config.Configuration.GetConnectionString(connectionStringName);
            return connectinStr;
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<ResDepartment> ResDepartments
        {
            get;
            set;
        }

        public virtual DbSet<ResRole> ResRoles
        {
            get;
            set;
        }

        public virtual DbSet<ResResource> ResResources
        {
            get;
            set;
        }

        public virtual DbSet<ResPermission> ResPermissions
        {
            get;
            set;
        }

        public virtual DbSet<ResUser> ResUsers
        {
            get;
            set;
        }

        public virtual DbSet<ResUserRole> ResUserRoles
        {
            get;
            set;
        }

        public virtual DbSet<ResRolePermission> ResRolePermissions
        {
            get;
            set;
        }

        public virtual DbSet<ResUserPermission> ResUserPermissions
        {
            get;
            set;
        }

        public virtual DbSet<ResAutoCode> ResAutoCodes
        {
            get;
            set;
        }

        public virtual DbSet<ResSchedule> ResSchedules
        {
            get;
            set;
        }

        public virtual DbSet<ResOperateLog> ResOperateLogs
        {
            get;
            set;
        }

        #region Methods

        public void GetAutoCode(string fixHeader, int? length, ref string code)
        {

            DbConnection connection = this.Database.GetDbConnection();
            bool needClose = false;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                needClose = true;
            }

            try
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    if (this.Database.GetCommandTimeout().HasValue)
                        cmd.CommandTimeout = this.Database.GetCommandTimeout().Value;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"dbo.GetAutoCode";

                    DbParameter fixHeaderParameter = cmd.CreateParameter();
                    fixHeaderParameter.ParameterName = "fixHeader";
                    fixHeaderParameter.Direction = ParameterDirection.Input;
                    fixHeaderParameter.DbType = DbType.String;
                    fixHeaderParameter.Size = 20;
                    if (fixHeader != null)
                    {
                        fixHeaderParameter.Value = fixHeader;
                    }
                    else
                    {
                        fixHeaderParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(fixHeaderParameter);

                    DbParameter lengthParameter = cmd.CreateParameter();
                    lengthParameter.ParameterName = "length";
                    lengthParameter.Direction = ParameterDirection.Input;
                    lengthParameter.DbType = DbType.Int32;
                    lengthParameter.Precision = 10;
                    lengthParameter.Scale = 0;
                    if (length.HasValue)
                    {
                        lengthParameter.Value = length.Value;
                    }
                    else
                    {
                        lengthParameter.Size = -1;
                        lengthParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(lengthParameter);

                    DbParameter codeParameter = cmd.CreateParameter();
                    codeParameter.ParameterName = "code";
                    codeParameter.Direction = ParameterDirection.InputOutput;
                    codeParameter.DbType = DbType.String;
                    codeParameter.Size = 60;
                    if (code != null)
                    {
                        codeParameter.Value = code;
                    }
                    else
                    {
                        codeParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(codeParameter);
                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["code"].Value != null && !(cmd.Parameters["code"].Value is System.DBNull))
                        code = (string)Convert.ChangeType(cmd.Parameters["code"].Value, typeof(string));
                    else
                        code = default(string);
                }
            }
            finally
            {
                if (needClose)
                    connection.Close();
            }
        }

        public async Task<Tuple<string>> GetAutoCodeAsync(string fixHeader, int? length, string code)
        {

            DbConnection connection = this.Database.GetDbConnection();
            bool needClose = false;
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
                needClose = true;
            }

            try
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    if (this.Database.GetCommandTimeout().HasValue)
                        cmd.CommandTimeout = this.Database.GetCommandTimeout().Value;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"dbo.GetAutoCode";

                    DbParameter fixHeaderParameter = cmd.CreateParameter();
                    fixHeaderParameter.ParameterName = "fixHeader";
                    fixHeaderParameter.Direction = ParameterDirection.Input;
                    fixHeaderParameter.DbType = DbType.String;
                    fixHeaderParameter.Size = 20;
                    if (fixHeader != null)
                    {
                        fixHeaderParameter.Value = fixHeader;
                    }
                    else
                    {
                        fixHeaderParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(fixHeaderParameter);

                    DbParameter lengthParameter = cmd.CreateParameter();
                    lengthParameter.ParameterName = "length";
                    lengthParameter.Direction = ParameterDirection.Input;
                    lengthParameter.DbType = DbType.Int32;
                    lengthParameter.Precision = 10;
                    lengthParameter.Scale = 0;
                    if (length.HasValue)
                    {
                        lengthParameter.Value = length.Value;
                    }
                    else
                    {
                        lengthParameter.Size = -1;
                        lengthParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(lengthParameter);

                    DbParameter codeParameter = cmd.CreateParameter();
                    codeParameter.ParameterName = "code";
                    codeParameter.Direction = ParameterDirection.InputOutput;
                    codeParameter.DbType = DbType.String;
                    codeParameter.Size = 60;
                    if (code != null)
                    {
                        codeParameter.Value = code;
                    }
                    else
                    {
                        codeParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(codeParameter);
                    await cmd.ExecuteNonQueryAsync();

                    if (cmd.Parameters["code"].Value != null && !(cmd.Parameters["code"].Value is System.DBNull))
                        code = (string)Convert.ChangeType(cmd.Parameters["code"].Value, typeof(string));
                    else
                        code = default(string);
                }
            }
            finally
            {
                if (needClose)
                    connection.Close();
            }
            return new Tuple<string>(code);
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ResDepartmentMapping(modelBuilder);
            this.CustomizeResDepartmentMapping(modelBuilder);

            this.ResRoleMapping(modelBuilder);
            this.CustomizeResRoleMapping(modelBuilder);

            this.ResResourceMapping(modelBuilder);
            this.CustomizeResResourceMapping(modelBuilder);

            this.ResPermissionMapping(modelBuilder);
            this.CustomizeResPermissionMapping(modelBuilder);

            this.ResUserMapping(modelBuilder);
            this.CustomizeResUserMapping(modelBuilder);

            this.ResUserRoleMapping(modelBuilder);
            this.CustomizeResUserRoleMapping(modelBuilder);

            this.ResRolePermissionMapping(modelBuilder);
            this.CustomizeResRolePermissionMapping(modelBuilder);

            this.ResUserPermissionMapping(modelBuilder);
            this.CustomizeResUserPermissionMapping(modelBuilder);

            this.ResAutoCodeMapping(modelBuilder);
            this.CustomizeResAutoCodeMapping(modelBuilder);

            this.ResScheduleMapping(modelBuilder);
            this.CustomizeResScheduleMapping(modelBuilder);

            this.ResOperateLogMapping(modelBuilder);
            this.CustomizeResOperateLogMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region ResDepartment Mapping

        private void ResDepartmentMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResDepartment>().ToTable(@"Res_Department");
            modelBuilder.Entity<ResDepartment>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResDepartment>().Property<string>(x => x.DeptCode).HasColumnName(@"DeptCode").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResDepartment>().Property<string>(x => x.DeptName).HasColumnName(@"DeptName").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ResDepartment>().Property<string>(x => x.Remark).HasColumnName(@"Remark").IsRequired().ValueGeneratedNever().HasMaxLength(512);
            modelBuilder.Entity<ResDepartment>().Property<int?>(x => x.ParentId).HasColumnName(@"ParentId").ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().Property<bool>(x => x.StopFlag).HasColumnName(@"StopFlag").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResDepartment>().HasKey(@"Id");
        }

        partial void CustomizeResDepartmentMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResRole Mapping

        private void ResRoleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResRole>().ToTable(@"Res_Role");
            modelBuilder.Entity<ResRole>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResRole>().Property<string>(x => x.RoleCode).HasColumnName(@"RoleCode").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResRole>().Property<string>(x => x.RoleName).HasColumnName(@"RoleName").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ResRole>().Property<string>(x => x.Remark).HasColumnName(@"Remark").IsRequired().ValueGeneratedNever().HasMaxLength(512);
            modelBuilder.Entity<ResRole>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRole>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRole>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRole>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRole>().HasKey(@"Id");
        }

        partial void CustomizeResRoleMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResResource Mapping

        private void ResResourceMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResResource>().ToTable(@"Res_Resource");
            modelBuilder.Entity<ResResource>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResResource>().Property<string>(x => x.ResourceCode).HasColumnName(@"ResourceCode").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResResource>().Property<string>(x => x.EnName).HasColumnName(@"EnName").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ResResource>().Property<string>(x => x.CnName).HasColumnName(@"CnName").ValueGeneratedNever().HasMaxLength(256);
            modelBuilder.Entity<ResResource>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResResource>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResResource>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResResource>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResResource>().HasKey(@"Id");
        }

        partial void CustomizeResResourceMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResPermission Mapping

        private void ResPermissionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResPermission>().ToTable(@"Res_Permission");
            modelBuilder.Entity<ResPermission>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResPermission>().Property<int>(x => x.ResResourceId).HasColumnName(@"ResResourceId").ValueGeneratedNever();
            modelBuilder.Entity<ResPermission>().Property<string>(x => x.PermissionCode).HasColumnName(@"PermissionCode").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResPermission>().Property<string>(x => x.EnName).HasColumnName(@"EnName").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ResPermission>().Property<string>(x => x.CnName).HasColumnName(@"CnName").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ResPermission>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResPermission>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResPermission>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResPermission>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResPermission>().Property<bool>(x => x.StopFlage).HasColumnName(@"StopFlage").IsRequired().ValueGeneratedNever().HasDefaultValueSql(@"0");
            modelBuilder.Entity<ResPermission>().HasKey(@"Id");
        }

        partial void CustomizeResPermissionMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResUser Mapping

        private void ResUserMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUser>().ToTable(@"Res_User");
            modelBuilder.Entity<ResUser>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResUser>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<string>(x => x.UserName).HasColumnName(@"UserName").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.UserCode).HasColumnName(@"UserCode").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.RealName).HasColumnName(@"RealName").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.UserPwd).HasColumnName(@"UserPwd").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ResUser>().Property<int>(x => x.DeptId).HasColumnName(@"DeptId").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<bool>(x => x.StopFlag).HasColumnName(@"StopFlag").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<bool>(x => x.AdminFlag).HasColumnName(@"AdminFlag").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<string>(x => x.Phone).HasColumnName(@"Phone").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.Email).HasColumnName(@"Email").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.Remark).HasColumnName(@"Remark").IsRequired().ValueGeneratedNever().HasMaxLength(512);
            modelBuilder.Entity<ResUser>().Property<string>(x => x.HeadUrl).HasColumnName(@"HeadUrl").IsRequired().ValueGeneratedNever().HasMaxLength(512);
            modelBuilder.Entity<ResUser>().Property<System.DateTime>(x => x.LoginDate).HasColumnName(@"LoginDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUser>().Property<string>(x => x.Salt).HasColumnName(@"Salt").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ResUser>().HasKey(@"Id");
        }

        partial void CustomizeResUserMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResUserRole Mapping

        private void ResUserRoleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUserRole>().ToTable(@"Res_UserRole");
            modelBuilder.Entity<ResUserRole>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResUserRole>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().Property<int>(x => x.RoleId).HasColumnName(@"RoleId").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().Property<int>(x => x.UserId).HasColumnName(@"UserId").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserRole>().HasKey(@"Id");
        }

        partial void CustomizeResUserRoleMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResRolePermission Mapping

        private void ResRolePermissionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResRolePermission>().ToTable(@"Res_RolePermission");
            modelBuilder.Entity<ResRolePermission>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResRolePermission>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().Property<int>(x => x.RoleId).HasColumnName(@"RoleId").ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().Property<int>(x => x.PermissionId).HasColumnName(@"PermissionId").ValueGeneratedNever();
            modelBuilder.Entity<ResRolePermission>().HasKey(@"Id");
        }

        partial void CustomizeResRolePermissionMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResUserPermission Mapping

        private void ResUserPermissionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUserPermission>().ToTable(@"Res_UserPermission");
            modelBuilder.Entity<ResUserPermission>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResUserPermission>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().Property<int>(x => x.UserId).HasColumnName(@"UserId").ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().Property<int>(x => x.PermissionId).HasColumnName(@"PermissionId").ValueGeneratedNever();
            modelBuilder.Entity<ResUserPermission>().HasKey(@"Id");
        }

        partial void CustomizeResUserPermissionMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResAutoCode Mapping

        private void ResAutoCodeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResAutoCode>().ToTable(@"Res_AutoCode");
            modelBuilder.Entity<ResAutoCode>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResAutoCode>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResAutoCode>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResAutoCode>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResAutoCode>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResAutoCode>().Property<string>(x => x.FixHeader).HasColumnName(@"FixHeader").IsRequired().ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<ResAutoCode>().Property<int>(x => x.Current).HasColumnName(@"Current").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResAutoCode>().HasKey(@"Id");
            modelBuilder.Entity<ResAutoCode>().HasIndex(@"FixHeader").IsUnique(true).HasName(@"Res_AutoCode_FixHeader");
        }

        partial void CustomizeResAutoCodeMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResSchedule Mapping

        private void ResScheduleMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResSchedule>().ToTable(@"Res_Schedule");
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.JobName).HasColumnName(@"JobName").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.JobGroup).HasColumnName(@"JobGroup").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.JobStatus).HasColumnName(@"JobStatus").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.Cron).HasColumnName(@"Cron").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.AssemblyName).HasColumnName(@"AssemblyName").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.ClassName).HasColumnName(@"ClassName").IsRequired().ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.Remark).HasColumnName(@"Remark").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<System.DateTime>(x => x.BeginTime).HasColumnName(@"BeginTime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<System.DateTime?>(x => x.EndTime).HasColumnName(@"EndTime").ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.TriggerType).HasColumnName(@"TriggerType").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<int>(x => x.IntervalSecond).HasColumnName(@"IntervalSecond").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().Property<string>(x => x.Url).HasColumnName(@"Url").IsRequired().ValueGeneratedNever().HasMaxLength(300);
            modelBuilder.Entity<ResSchedule>().Property<System.DateTime>(x => x.NextRunTime).HasColumnName(@"NextRunTime").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResSchedule>().HasKey(@"Id");
        }

        partial void CustomizeResScheduleMapping(ModelBuilder modelBuilder);

        #endregion

        #region ResOperateLog Mapping

        private void ResOperateLogMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResOperateLog>().ToTable(@"Res_OperateLog");
            modelBuilder.Entity<ResOperateLog>().Property<int>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ResOperateLog>().Property<int>(x => x.CreateUid).HasColumnName(@"CreateUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<System.DateTime>(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<int>(x => x.WriteUid).HasColumnName(@"WriteUid").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<System.DateTime>(x => x.WriteDate).HasColumnName(@"WriteDate").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<string>(x => x.TableName).HasColumnName(@"TableName").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<int>(x => x.Type).HasColumnName(@"Type").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().Property<string>(x => x.Describe).HasColumnName(@"Describe").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ResOperateLog>().HasKey(@"Id");
        }

        partial void CustomizeResOperateLogMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {

            #region ResDepartment Navigation properties

            modelBuilder.Entity<ResDepartment>().HasMany(x => x.ChildrenDept).WithOne(op => op.ParentDept).IsRequired(false).HasForeignKey(@"ParentId");
            modelBuilder.Entity<ResDepartment>().HasOne(x => x.ParentDept).WithMany(op => op.ChildrenDept).IsRequired(false).HasForeignKey(@"ParentId");
            modelBuilder.Entity<ResDepartment>().HasMany(x => x.ResUsers).WithOne(op => op.ResDepartment).IsRequired(true).HasForeignKey(@"DeptId");

            #endregion

            #region ResRole Navigation properties

            modelBuilder.Entity<ResRole>().HasMany(x => x.ResUserRoles).WithOne(op => op.ResRole).IsRequired(true).HasForeignKey(@"RoleId");
            modelBuilder.Entity<ResRole>().HasMany(x => x.ResRolePermissions).WithOne(op => op.ResRole).IsRequired(true).HasForeignKey(@"RoleId");

            #endregion

            #region ResResource Navigation properties

            modelBuilder.Entity<ResResource>().HasMany(x => x.ResPermissions).WithOne(op => op.ResResource).IsRequired(true).HasForeignKey(@"ResResourceId");

            #endregion

            #region ResPermission Navigation properties

            modelBuilder.Entity<ResPermission>().HasOne(x => x.ResResource).WithMany(op => op.ResPermissions).IsRequired(true).HasForeignKey(@"ResResourceId");
            modelBuilder.Entity<ResPermission>().HasMany(x => x.ResRolePermissions).WithOne(op => op.ResPermission).IsRequired(true).HasForeignKey(@"PermissionId");
            modelBuilder.Entity<ResPermission>().HasMany(x => x.ResUserPermissions).WithOne(op => op.ResPermission).IsRequired(true).HasForeignKey(@"PermissionId");

            #endregion

            #region ResUser Navigation properties

            modelBuilder.Entity<ResUser>().HasOne(x => x.ResDepartment).WithMany(op => op.ResUsers).IsRequired(true).HasForeignKey(@"DeptId");
            modelBuilder.Entity<ResUser>().HasMany(x => x.ResUserRoles).WithOne(op => op.ResUser).IsRequired(true).HasForeignKey(@"UserId");
            modelBuilder.Entity<ResUser>().HasMany(x => x.ResUserPermissions).WithOne(op => op.ResUser).IsRequired(true).HasForeignKey(@"UserId");

            #endregion

            #region ResUserRole Navigation properties

            modelBuilder.Entity<ResUserRole>().HasOne(x => x.ResRole).WithMany(op => op.ResUserRoles).IsRequired(true).HasForeignKey(@"RoleId");
            modelBuilder.Entity<ResUserRole>().HasOne(x => x.ResUser).WithMany(op => op.ResUserRoles).IsRequired(true).HasForeignKey(@"UserId");

            #endregion

            #region ResRolePermission Navigation properties

            modelBuilder.Entity<ResRolePermission>().HasOne(x => x.ResRole).WithMany(op => op.ResRolePermissions).IsRequired(true).HasForeignKey(@"RoleId");
            modelBuilder.Entity<ResRolePermission>().HasOne(x => x.ResPermission).WithMany(op => op.ResRolePermissions).IsRequired(true).HasForeignKey(@"PermissionId");

            #endregion

            #region ResUserPermission Navigation properties

            modelBuilder.Entity<ResUserPermission>().HasOne(x => x.ResUser).WithMany(op => op.ResUserPermissions).IsRequired(true).HasForeignKey(@"UserId");
            modelBuilder.Entity<ResUserPermission>().HasOne(x => x.ResPermission).WithMany(op => op.ResUserPermissions).IsRequired(true).HasForeignKey(@"PermissionId");

            #endregion
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
