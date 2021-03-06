﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Repository;
using Xin.Entities;
using Xin.Service;
using Xin.Common;
using log4net;
using System.Linq;

namespace Xin.ExternalService.EC.Job
{
    public class EcWarehouseInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcWarehouseInit(IUowProvider uowProvider)
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
            _uowProvider = uowProvider;
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {

            var request = new Reqeust.WMSGetWarehouseRequest(login.Username, login.Password);
            log.Info("仓库数据 - 开始拉取");
            try
            {
                var response = await request.Request();
                if (response.Code == "200")
                {
                    using (var uow = _uowProvider.CreateUnitOfWork())
                    {
                        var repository = uow.GetRepository<ECWarehouse>();
                        //删除表中原有数据
                        var oldEntities = await repository.GetAllAsync();
                        if (oldEntities != null && oldEntities.Count() > 0)
                            await repository.DeleteAll();
                        //批量写入新数据
                        var models = response.Body;
                        var entities = new List<ECWarehouse>();
                        foreach (var m in models)
                        {
                            var entity = Mapper<Response.Model.EC_Warehouse, ECWarehouse>.Map(m);
                            entities.Add(entity);
                        }
                        await repository.BulkInsertAsync(entities, x => x.IncludeGraph = true);
                        await uow.BulkSaveChangesAsync();
                        log.Info("仓库数据 - 拉取完成");
                    }
                }
                else
                {
                    log.Error($"仓库数据 - 返回异常:{response.GetErrorString()}");
                    throw new ECExceptoin("仓库信息初始化错误", response.Error);
                }
            }
            catch (Exception ex)
            {
                log.Error($"仓库数据 - 请求异常:{ex.Message}");
                throw ex;
            }
        }
    }
}
