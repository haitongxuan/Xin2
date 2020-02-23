﻿using System;
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

        public virtual DbSet<ECOrderConfigData> ECOrderConfigDatas
        {
            get;
            set;
        }

        public virtual DbSet<ECProduct> ECProducts
        {
            get;
            set;
        }

        public virtual DbSet<ECProductBox> ECProductBoxes
        {
            get;
            set;
        }

        public virtual DbSet<ECProductCombination> ECProductCombinations
        {
            get;
            set;
        }

        public virtual DbSet<ECProductCustomCategory> ECProductCustomCategories
        {
            get;
            set;
        }

        public virtual DbSet<ECProductProperty> ECProductProperties
        {
            get;
            set;
        }

        public virtual DbSet<ECSalesOrder> ECSalesOrders
        {
            get;
            set;
        }

        public virtual DbSet<ECSalesOrderAddress> ECSalesOrderAddresses
        {
            get;
            set;
        }

        public virtual DbSet<ECSubProduct> ECSubProducts
        {
            get;
            set;
        }

        public virtual DbSet<ECWarehouse> ECWarehouses
        {
            get;
            set;
        }

        public virtual DbSet<ECSalesOrderDetail> ECSalesOrderDetails
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

            this.ECOrderConfigDataMapping(modelBuilder);
            this.CustomizeECOrderConfigDataMapping(modelBuilder);

            this.ECProductMapping(modelBuilder);
            this.CustomizeECProductMapping(modelBuilder);

            this.ECProductBoxMapping(modelBuilder);
            this.CustomizeECProductBoxMapping(modelBuilder);

            this.ECProductCombinationMapping(modelBuilder);
            this.CustomizeECProductCombinationMapping(modelBuilder);

            this.ECProductCustomCategoryMapping(modelBuilder);
            this.CustomizeECProductCustomCategoryMapping(modelBuilder);

            this.ECProductPropertyMapping(modelBuilder);
            this.CustomizeECProductPropertyMapping(modelBuilder);

            this.ECSalesOrderMapping(modelBuilder);
            this.CustomizeECSalesOrderMapping(modelBuilder);

            this.ECSalesOrderAddressMapping(modelBuilder);
            this.CustomizeECSalesOrderAddressMapping(modelBuilder);

            this.ECSubProductMapping(modelBuilder);
            this.CustomizeECSubProductMapping(modelBuilder);

            this.ECWarehouseMapping(modelBuilder);
            this.CustomizeECWarehouseMapping(modelBuilder);

            this.ECSalesOrderDetailMapping(modelBuilder);
            this.CustomizeECSalesOrderDetailMapping(modelBuilder);

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

        #region ECOrderConfigData Mapping

        private void ECOrderConfigDataMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECOrderConfigData>().ToTable(@"EC_OrderConfigDatas", @"dbo");
            modelBuilder.Entity<ECOrderConfigData>().Property<string>(x => x.OriginalOrderId).HasColumnName(@"OriginalOrderId").HasColumnType(@"nvarchar(64)").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECOrderConfigData>().Property<string>(x => x.OriginalAccount).HasColumnName(@"OriginalAccount").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECOrderConfigData>().Property<string>(x => x.EbayOrders).HasColumnName(@"EbayOrders").HasColumnType(@"text").ValueGeneratedNever().HasMaxLength(2147483647);
            modelBuilder.Entity<ECOrderConfigData>().Property<string>(x => x.EbayOrderDetail).HasColumnName(@"EbayOrderDetail").HasColumnType(@"text").ValueGeneratedNever().HasMaxLength(2147483647);
            modelBuilder.Entity<ECOrderConfigData>().HasKey(@"OriginalOrderId");
        }

        partial void CustomizeECOrderConfigDataMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECProduct Mapping

        private void ECProductMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECProduct>().ToTable(@"EC_Product", @"dbo");
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProductSku).HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(64)").IsRequired().ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProductTitle).HasColumnName(@"ProductTitle").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProductTitleEn).HasColumnName(@"ProductTitleEn").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProductSpu).HasColumnName(@"ProductSpu").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductDeclaredValue).HasColumnName(@"ProductDeclaredValue").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.PdDeclareCurrencyCode).HasColumnName(@"PdDeclareCurrencyCode").HasColumnType(@"nvarchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductWeight).HasColumnName(@"ProductWeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductNetWeight).HasColumnName(@"ProductNetWeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.DefaultSupplierCode).HasColumnName(@"DefaultSupplierCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.ProductStatus).HasColumnName(@"ProductStatus").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.SaleStatus).HasColumnName(@"SaleStatus").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<bool?>(x => x.IsQc).HasColumnName(@"IsQc").HasColumnType(@"bit").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<bool?>(x => x.IsExpDate).HasColumnName(@"IsExpDate").HasColumnType(@"bit").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<bool?>(x => x.IsGift).HasColumnName(@"IsGift").HasColumnType(@"bit").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.WarehouseBarcode).HasColumnName(@"WarehouseBarcode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductLength).HasColumnName(@"ProductLength").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductWidth).HasColumnName(@"ProductWidth").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<decimal?>(x => x.ProductHeight).HasColumnName(@"ProductHeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.DesignerId).HasColumnName(@"DesignerId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.PersonOpraterId).HasColumnName(@"PersonOpraterId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.PersonSellerId).HasColumnName(@"PersonSellerId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.PersonDevelopId).HasColumnName(@"PersonDevelopId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<System.DateTime?>(x => x.ProductAddTime).HasColumnName(@"ProductAddTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<System.DateTime?>(x => x.ProductUpdateTime).HasColumnName(@"ProductUpdateTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<System.DateTime?>(x => x.PpnReleaseDate).HasColumnName(@"PpnReleaseDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.IsCombination).HasColumnName(@"IsCombination").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.ProductColorId).HasColumnName(@"ProductColorId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.ProductSizeId).HasColumnName(@"ProductSizeId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.PuName).HasColumnName(@"PuName").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.UserOrganizationId).HasColumnName(@"UserOrganizationId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.DefaultWarehouseId).HasColumnName(@"DefaultWarehouseId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.EanCode).HasColumnName(@"EanCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryCode1).HasColumnName(@"ProcutCategoryCode1").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryCode2).HasColumnName(@"ProcutCategoryCode2").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryCode3).HasColumnName(@"ProcutCategoryCode3").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryName1).HasColumnName(@"ProcutCategoryName1").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryName2).HasColumnName(@"ProcutCategoryName2").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProcutCategoryName3).HasColumnName(@"ProcutCategoryName3").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<int?>(x => x.OprationType).HasColumnName(@"OprationType").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.BrandCode).HasColumnName(@"BrandCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.BrandName).HasColumnName(@"BrandName").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.PrlCode).HasColumnName(@"PrlCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.PrlName).HasColumnName(@"PrlName").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.CurrencyCode).HasColumnName(@"CurrencyCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.SpUnitPrice).HasColumnName(@"SpUnitPrice").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProduct>().Property<string>(x => x.ProductImages).HasColumnName(@"ProductImages").HasColumnType(@"nvarchar(500)").ValueGeneratedNever().HasMaxLength(500);
            modelBuilder.Entity<ECProduct>().HasKey(@"ProductSku");
        }

        partial void CustomizeECProductMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECProductBox Mapping

        private void ECProductBoxMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECProductBox>().ToTable(@"EC_ProductBox", @"dbo");
            modelBuilder.Entity<ECProductBox>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ECProductBox>().Property<string>(x => x.BoxName).HasColumnName(@"BoxName").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductBox>().Property<string>(x => x.BoxNameEn).HasColumnName(@"boxNameEn").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductBox>().Property<decimal?>(x => x.BoxWidth).HasColumnName(@"boxWidth").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<decimal?>(x => x.BoxHeight).HasColumnName(@"boxHeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<decimal?>(x => x.BoxWeight).HasColumnName(@"boxWeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<decimal?>(x => x.BoxLength).HasColumnName(@"boxLength").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<int?>(x => x.Quantity).HasColumnName(@"quantity").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<int?>(x => x.BoxStatus).HasColumnName(@"boxStatus").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECProductBox>().Property<string>(@"ProductSku").HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProductBox>().HasKey(@"Id");
        }

        partial void CustomizeECProductBoxMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECProductCombination Mapping

        private void ECProductCombinationMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECProductCombination>().ToTable(@"EC_ProductCombination", @"dbo");
            modelBuilder.Entity<ECProductCombination>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ECProductCombination>().Property<string>(x => x.PcrFnsku).HasColumnName(@"PcrFnsku").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductCombination>().Property<string>(x => x.PcrFbaAsin).HasColumnName(@"PcrFbaAsin").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductCombination>().Property<string>(x => x.WarehouseId).HasColumnName(@"WarehouseId").HasColumnType(@"nvarchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<ECProductCombination>().Property<System.DateTime?>(x => x.PcrAddTime).HasColumnName(@"PcrAddTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECProductCombination>().Property<System.DateTime?>(x => x.PcrUpdateTime).HasColumnName(@"PcrUpdateTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECProductCombination>().Property<string>(@"ProductSku").HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProductCombination>().HasKey(@"Id");
        }

        partial void CustomizeECProductCombinationMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECProductCustomCategory Mapping

        private void ECProductCustomCategoryMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECProductCustomCategory>().ToTable(@"EC_ProductCustomCategory", @"dbo");
            modelBuilder.Entity<ECProductCustomCategory>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ECProductCustomCategory>().Property<string>(x => x.PucName).HasColumnName(@"PucName").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductCustomCategory>().Property<string>(@"ProductSku").HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProductCustomCategory>().HasKey(@"Id");
        }

        partial void CustomizeECProductCustomCategoryMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECProductProperty Mapping

        private void ECProductPropertyMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECProductProperty>().ToTable(@"EC_ProductProperty", @"dbo");
            modelBuilder.Entity<ECProductProperty>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ECProductProperty>().Property<string>(x => x.AttrName).HasColumnName(@"AttrName").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductProperty>().Property<string>(x => x.AttrNameEn).HasColumnName(@"AttrNameEn").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECProductProperty>().Property<decimal?>(x => x.AttrValue).HasColumnName(@"AttrValue").HasColumnType(@"decimal(12,4)").ValueGeneratedNever();
            modelBuilder.Entity<ECProductProperty>().Property<string>(@"ProductSku").HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECProductProperty>().HasKey(@"Id");
        }

        partial void CustomizeECProductPropertyMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECSalesOrder Mapping

        private void ECSalesOrderMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECSalesOrder>().ToTable(@"EC_SalesOrder", @"dbo");
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.OrderId).HasColumnName(@"OrderId").HasColumnType(@"nvarchar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.Plateform).HasColumnName(@"Plateform").HasColumnType(@"nvarchar(20)").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.OrderType).HasColumnName(@"OrderType").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<int?>(x => x.Status).HasColumnName(@"Status").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<int?>(x => x.ProcessAgain).HasColumnName(@"ProcessAgain").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.RefNo).HasColumnName(@"RefNo").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.SaleOrderCode).HasColumnName(@"SaleOrderCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.SysOrderCode).HasColumnName(@"SysOrderCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.WarehouseOrderCode).HasColumnName(@"WarehouseOrderCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.CompanyCode).HasColumnName(@"CompanyCode").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.UserAccount).HasColumnName(@"UserAccount").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.PlatformUserName).HasColumnName(@"PlatformUserName").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.ShippingMethod).HasColumnName(@"ShippingMethod").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.ShippingMethodNo).HasColumnName(@"ShippingMethodNo").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.ShippingMethodPlatform).HasColumnName(@"ShippingMethodPlatform").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<int?>(@"WarehouseId").HasColumnName(@"WarehouseId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.WarehouseCode).HasColumnName(@"WarehouseCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.DatePaidPlatform).HasColumnName(@"DatePaidPlatform").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<int?>(x => x.PlatformShipStatus).HasColumnName(@"PlatformShipStatus").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.PlatformShipTime).HasColumnName(@"PlatformShipTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.DateWarehouseShipping).HasColumnName(@"DateWarehouseShipping").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<System.DateTime?>(x => x.DateLatestShip).HasColumnName(@"DateLatestShip").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.Currency).HasColumnName(@"Currency").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.Amountpaid).HasColumnName(@"Amountpaid").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.Subtotal).HasColumnName(@"Subtotal").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.ShipFee).HasColumnName(@"ShipFee").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.PlatformFeeTotal).HasColumnName(@"PlatformFeeTotal").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.FinalvaluefeeTotal).HasColumnName(@"FinalvaluefeeTotal").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.OtherFee).HasColumnName(@"OtherFee").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.CostShipFee).HasColumnName(@"CostShipFee").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.BuyerId).HasColumnName(@"BuyerId").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.BuyerName).HasColumnName(@"BuyerName").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.BuyerMail).HasColumnName(@"BuyerMail").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.Site).HasColumnName(@"Site").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.CountryCode).HasColumnName(@"CountryCode").HasColumnType(@"nvarchar(2)").ValueGeneratedNever().HasMaxLength(2);
            modelBuilder.Entity<ECSalesOrder>().Property<int?>(x => x.ProductCount).HasColumnName(@"ProductCount").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<decimal?>(x => x.OrderWeight).HasColumnName(@"OrderWeight").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.OrderDesc).HasColumnName(@"OrderDesc").HasColumnType(@"nvarchar(1500)").ValueGeneratedNever().HasMaxLength(1500);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.PaypalTransactionId).HasColumnName(@"PaypalTransactionId").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.PaymentMethod).HasColumnName(@"PaymentMethod").HasColumnType(@"nvarchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ECSalesOrder>().Property<byte?>(x => x.AbnormalType).HasColumnName(@"AbnormalType").HasColumnType(@"tinyint").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.AbnormalReason).HasColumnName(@"AbnormalReason").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(@"ShippingAddressId").HasColumnName(@"ShippingAddressId").HasColumnType(@"nvarchar(11)").ValueGeneratedNever().HasMaxLength(11);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(@"OriginalOrderId").HasColumnName(@"OriginalOrderId").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrder>().Property<string>(x => x.SyncCode).HasColumnName(@"SyncCode").HasColumnType(@"nvarchar(20)").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrder>().HasKey(@"OrderId");
        }

        partial void CustomizeECSalesOrderMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECSalesOrderAddress Mapping

        private void ECSalesOrderAddressMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECSalesOrderAddress>().ToTable(@"EC_SalesOrderAddress", @"dbo");
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.ShippingAddressId).HasColumnName(@"ShippingAddressId").HasColumnType(@"nvarchar(11)").IsRequired().ValueGeneratedNever().HasMaxLength(11);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.CountryCode).HasColumnName(@"CountryCode").HasColumnType(@"nvarchar(2)").ValueGeneratedNever().HasMaxLength(2);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.CountryName).HasColumnName(@"CountryName").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.CityName).HasColumnName(@"CityName").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Line1).HasColumnName(@"Line1").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Line2).HasColumnName(@"Line2").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Line3).HasColumnName(@"Line3").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.District).HasColumnName(@"District").HasColumnType(@"nvarchar(60)").ValueGeneratedNever().HasMaxLength(60);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.State).HasColumnName(@"State").HasColumnType(@"nvarchar(20)").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Doorplate).HasColumnName(@"Doorplate").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<string>(x => x.Phone).HasColumnName(@"Phone").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECSalesOrderAddress>().Property<System.DateTime?>(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderAddress>().Property<System.DateTime?>(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderAddress>().HasKey(@"ShippingAddressId");
        }

        partial void CustomizeECSalesOrderAddressMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECSubProduct Mapping

        private void ECSubProductMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECSubProduct>().ToTable(@"EC_SubProducts", @"dbo");
            modelBuilder.Entity<ECSubProduct>().Property<int>(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ECSubProduct>().Property<string>(x => x.PcrProductSku).HasColumnName(@"pcrProductSku").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSubProduct>().Property<int?>(x => x.PcrQty).HasColumnName(@"pcrQty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSubProduct>().Property<int?>(@"PrudoctCombinationId").HasColumnName(@"PrudoctCombinationId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSubProduct>().HasKey(@"Id");
        }

        partial void CustomizeECSubProductMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECWarehouse Mapping

        private void ECWarehouseMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECWarehouse>().ToTable(@"EC_Warehouse", @"dbo");
            modelBuilder.Entity<ECWarehouse>().Property<int>(x => x.WarehouseId).HasColumnName(@"WarehouseId").HasColumnType(@"int").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.WarehouseCode).HasColumnName(@"WarehouseCode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.WarehouseDesc).HasColumnName(@"WarehouseDesc").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECWarehouse>().Property<int?>(x => x.WarehouseType).HasColumnName(@"WarehouseType").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<int?>(x => x.WarehouseStatus).HasColumnName(@"WarehouseStatus").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<int?>(x => x.WarehouseVirtual).HasColumnName(@"WarehouseVirtual").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.WarehouseService).HasColumnName(@"WarehouseService").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECWarehouse>().Property<int?>(x => x.IsTransfer).HasColumnName(@"IsTransfer").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.CountryCode).HasColumnName(@"CountryCode").HasColumnType(@"nvarchar(2)").ValueGeneratedNever().HasMaxLength(2);
            modelBuilder.Entity<ECWarehouse>().Property<int?>(x => x.CountryId).HasColumnName(@"CountryId").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.State).HasColumnName(@"State").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.City).HasColumnName(@"City").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.Contacter).HasColumnName(@"Contacter").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.Company).HasColumnName(@"Company").HasColumnType(@"nvarchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.PhoneNo).HasColumnName(@"PhoneNo").HasColumnType(@"nvarchar(64)").ValueGeneratedNever().HasMaxLength(64);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.StreetAddress1).HasColumnName(@"StreetAddress1").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.StreetAddress2).HasColumnName(@"StreetAddress2").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.Postcode).HasColumnName(@"Postcode").HasColumnType(@"nvarchar(32)").ValueGeneratedNever().HasMaxLength(32);
            modelBuilder.Entity<ECWarehouse>().Property<string>(x => x.StreetNumber).HasColumnName(@"StreetNumber").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECWarehouse>().Property<System.DateTime?>(x => x.WarehouseAddTime).HasColumnName(@"WarehouseAddTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().Property<System.DateTime?>(x => x.WarehouseUpdateTime).HasColumnName(@"WarehouseUpdateTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECWarehouse>().HasKey(@"WarehouseId");
        }

        partial void CustomizeECWarehouseMapping(ModelBuilder modelBuilder);

        #endregion

        #region ECSalesOrderDetail Mapping

        private void ECSalesOrderDetailMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECSalesOrderDetail>().ToTable(@"EC_SalesOrderDetail", @"dbo");
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.OpId).HasColumnName(@"OpId").HasColumnType(@"nvarchar(20)").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(@"OrderId").HasColumnName(@"OrderId").HasColumnType(@"nvarchar(20)").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.ProductSku).HasColumnName(@"ProductSku").HasColumnType(@"nvarchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.Sku).HasColumnName(@"Sku").HasColumnType(@"nvarchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.WarehouseSku).HasColumnName(@"WarehouseSku").HasColumnType(@"nvarchar(100)").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<decimal?>(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderDetail>().Property<int?>(x => x.Qty).HasColumnName(@"Qty").HasColumnType(@"int").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.ProductTitle).HasColumnName(@"ProductTitle").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.Pic).HasColumnName(@"Pic").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.OpSite).HasColumnName(@"OpSite").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.ProductUrl).HasColumnName(@"ProductUrl").HasColumnType(@"nvarchar(200)").ValueGeneratedNever().HasMaxLength(200);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.RefItemId).HasColumnName(@"RefItemId").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<string>(x => x.OpRefItemLocation).HasColumnName(@"OpRefItemLocation").HasColumnType(@"nvarchar(128)").ValueGeneratedNever().HasMaxLength(128);
            modelBuilder.Entity<ECSalesOrderDetail>().Property<decimal?>(x => x.UnitFinalValueFee).HasColumnName(@"UnitFinalValueFee").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderDetail>().Property<decimal?>(x => x.TransactionPrice).HasColumnName(@"TransactionPrice").HasColumnType(@"decimal(12,2)").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderDetail>().Property<System.DateTime?>(x => x.OperTime).HasColumnName(@"OperTime").HasColumnType(@"datetime").ValueGeneratedNever();
            modelBuilder.Entity<ECSalesOrderDetail>().HasKey(@"OpId");
        }

        partial void CustomizeECSalesOrderDetailMapping(ModelBuilder modelBuilder);

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

            #region ECOrderConfigData Navigation properties

            modelBuilder.Entity<ECOrderConfigData>().HasMany(x => x.ECSalesOrders).WithOne(op => op.ECOrderConfigData).IsRequired(false).HasForeignKey(@"OriginalOrderId");

            #endregion

            #region ECProduct Navigation properties

            modelBuilder.Entity<ECProduct>().HasMany(x => x.ECProductBoxes).WithOne(op => op.ECProduct).IsRequired(false).HasForeignKey(@"ProductSku");
            modelBuilder.Entity<ECProduct>().HasMany(x => x.ECProductCombinations).WithOne(op => op.ECProduct).IsRequired(false).HasForeignKey(@"ProductSku");
            modelBuilder.Entity<ECProduct>().HasMany(x => x.ECProductCustomCategories).WithOne(op => op.ECProduct).IsRequired(false).HasForeignKey(@"ProductSku");
            modelBuilder.Entity<ECProduct>().HasMany(x => x.ECProductProperties).WithOne(op => op.ECProduct).IsRequired(false).HasForeignKey(@"ProductSku");

            #endregion

            #region ECProductBox Navigation properties

            modelBuilder.Entity<ECProductBox>().HasOne(x => x.ECProduct).WithMany(op => op.ECProductBoxes).IsRequired(false).HasForeignKey(@"ProductSku");

            #endregion

            #region ECProductCombination Navigation properties

            modelBuilder.Entity<ECProductCombination>().HasOne(x => x.ECProduct).WithMany(op => op.ECProductCombinations).IsRequired(false).HasForeignKey(@"ProductSku");
            modelBuilder.Entity<ECProductCombination>().HasMany(x => x.ECSubProducts).WithOne(op => op.ECProductCombination).IsRequired(false).HasForeignKey(@"PrudoctCombinationId");

            #endregion

            #region ECProductCustomCategory Navigation properties

            modelBuilder.Entity<ECProductCustomCategory>().HasOne(x => x.ECProduct).WithMany(op => op.ECProductCustomCategories).IsRequired(false).HasForeignKey(@"ProductSku");

            #endregion

            #region ECProductProperty Navigation properties

            modelBuilder.Entity<ECProductProperty>().HasOne(x => x.ECProduct).WithMany(op => op.ECProductProperties).IsRequired(false).HasForeignKey(@"ProductSku");

            #endregion

            #region ECSalesOrder Navigation properties

            modelBuilder.Entity<ECSalesOrder>().HasOne(x => x.ECSalesOrderAddress).WithMany(op => op.ECSalesOrders).IsRequired(false).HasForeignKey(@"ShippingAddressId");
            modelBuilder.Entity<ECSalesOrder>().HasOne(x => x.ECOrderConfigData).WithMany(op => op.ECSalesOrders).IsRequired(false).HasForeignKey(@"OriginalOrderId");
            modelBuilder.Entity<ECSalesOrder>().HasOne(x => x.ECWarehouse).WithMany(op => op.ECSalesOrders).IsRequired(false).HasForeignKey(@"WarehouseId");
            modelBuilder.Entity<ECSalesOrder>().HasMany(x => x.ECSalesOrderDetails).WithOne(op => op.ECSalesOrder).IsRequired(false).HasForeignKey(@"OrderId");

            #endregion

            #region ECSalesOrderAddress Navigation properties

            modelBuilder.Entity<ECSalesOrderAddress>().HasMany(x => x.ECSalesOrders).WithOne(op => op.ECSalesOrderAddress).IsRequired(false).HasForeignKey(@"ShippingAddressId");

            #endregion

            #region ECSubProduct Navigation properties

            modelBuilder.Entity<ECSubProduct>().HasOne(x => x.ECProductCombination).WithMany(op => op.ECSubProducts).IsRequired(false).HasForeignKey(@"PrudoctCombinationId");

            #endregion

            #region ECWarehouse Navigation properties

            modelBuilder.Entity<ECWarehouse>().HasMany(x => x.ECSalesOrders).WithOne(op => op.ECWarehouse).IsRequired(false).HasForeignKey(@"WarehouseId");

            #endregion

            #region ECSalesOrderDetail Navigation properties

            modelBuilder.Entity<ECSalesOrderDetail>().HasOne(x => x.ECSalesOrder).WithMany(op => op.ECSalesOrderDetails).IsRequired(false).HasForeignKey(@"OrderId");

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
