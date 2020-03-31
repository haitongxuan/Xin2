using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xin.Common;
using Xin.Repository;
using Xin.Entities;
using Xin.Web.Framework.Model;
using Microsoft.AspNetCore.Authorization;
using Xin.Job.Model;
using Xin.Job.Server;
using Xin.Job.Service;
using log4net;
using log4net.Repository;
using log4net.Core;
using System.Security.Claims;
using Xin.Web.Framework.Permission;
using Xin.Web.Framework.Helper;

namespace Xin.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/Schedule")]
    public class ResScheduleController : Controller
    {
        private readonly IUowProvider _uowProvider;
        private readonly IDataPager<ResSchedule> _dataPager;
        private readonly ISchedulerCenter _schedulerCenter;
        private readonly LogHelper logger;
        public ResScheduleController(IUowProvider uowProvider, IDataPager<ResSchedule> dataPager,
            ISchedulerCenter schedulerCenter)
        {
            _uowProvider = uowProvider;
            _dataPager = dataPager;
            _schedulerCenter = schedulerCenter;
            logger = LogFactory.GetLogger(LogType.InfoLog);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="start">当前页</param>
        /// <param name="length">分页大小</param>
        /// <returns></returns>
        [Route("GetPage")]
        [HttpPost]
        [PermissionFilter("Schedule.Read")]
        public async Task<PageDataRes<ResSchedule>> GetPageAsync([FromBody]NavigateOrderPageDataReq pageReq)
        {
            var page = new PageDataRes<ResSchedule>();
            if (pageReq != null)
            {
                var query = pageReq.query;
                Filter<ResSchedule> filter = null;
                if (query.Count > 0)
                {
                    var fuc = FilterHelper<ResSchedule>.GetExpression(query, "schedulegetpage");
                    filter = new Repository.Filter<ResSchedule>(fuc);
                }
                OrderBy<ResSchedule> orderBy = null;
                if (pageReq.order!=null &&!string.IsNullOrWhiteSpace(pageReq.order.columnName))
                {
                    orderBy = new Repository.OrderBy<ResSchedule>(pageReq.order.columnName, pageReq.order.reverse);
                }
                try
                {
                    var result = await _dataPager.QueryAsync(
                        pageReq.pageNum, pageReq.pageSize, filter, orderBy, navigationPropertyPaths: null);
                    page = PageMapper<ResSchedule>.ToPageDateRes(result);
                    return page;
                }
                catch (Exception ex)
                {
                    page.code = ResCode.Error;
                    page.msg = ex.Message;
                    return page;
                }
            }
            else
            {
                page.code = ResCode.Error;
                page.msg = "参数不正确";
                return page;
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        [PermissionFilter("Schedule.Add")]
        public DataRes<bool> Add([FromBody]ResSchedule model)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ResSchedule>();
                    string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                    int userid = Convert.ToInt32(us);
                    model.CreateUid = userid;
                    model.WriteUid = userid;
                    model.CreateDate = DateTime.Now;
                    model.WriteDate = DateTime.Now;
                    repository.Add(model);
                    uow.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.Error;
                res.msg = $"{ex.Message}:{ex.InnerException.Message}";
            }
            return res;
        }

        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        [PermissionFilter("Schedule.Edit")]
        public DataRes<bool> Edit([FromBody]ResSchedule model)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<ResSchedule>();
                    string us = User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Sid)).Value;
                    int userid = Convert.ToInt32(us);
                    model.WriteUid = userid;
                    model.WriteDate = DateTime.Now;
                    repository.Update(model);
                    uow.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.Error;
                res.msg = $"{ex.Message}:{ex.InnerException.Message}";
            }
            return res;
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("Excute/{id}")]
        [HttpPost]
        [PermissionFilter("Schedule.Execute")]
        public DataRes<bool> Execute(int id)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResSchedule>();
                var model = repository.Get(id);
                var scheduleEntity = Mapper<ResSchedule, ScheduleEntity>.Map(model);
                //给IJob设置参数
                scheduleEntity.Agrs = new Dictionary<string, object> { { "orderId", id } };
                ScheduleManage.Instance.AddScheduleList(scheduleEntity);
                // 运行任务调度
                BaseQuartzNetResult result;
                if (model.TriggerType == 0)
                {
                    result = _schedulerCenter.RunScheduleJob<ScheduleManage, SubmitJobTask>(model.JobGroup, model.JobName).Result;
                }
                else
                {
                    result = _schedulerCenter.RunScheduleJob<ScheduleManage>(model.JobGroup, model.JobName).Result;
                }
                Console.Out.WriteLineAsync("任务执行状态：" + result.Msg);
                if (result.Code == 1000)
                {
                    model.JobStatus = 1;
                    model.WriteDate = DateTime.Now;
                    var t10 = repository.Update(model);
                    res.msg = result.Msg;
                    logger.Info($"任务执行中:{model.JobGroup}-{model.JobName},{result.Msg}");
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = result.Msg;
                    logger.Error($"任务执行失败:{model.JobGroup}-{model.JobName},{result.Msg}");
                }
            }
            return res;
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <returns></returns>
        [Route("Stop/{id}")]
        [HttpPost]
        [PermissionFilter("Schedule.Stop")]
        public DataRes<bool> Stop(int id)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResSchedule>();
                //根据任务编号获取任务详情
                var model = repository.Get(id);
                //停止指定任务
                var result = _schedulerCenter.StopScheduleJob<ScheduleManage>(model.JobGroup, model.JobName);
                if (result.Result.Code == 1000)
                {
                    model.JobStatus = 0;
                    model.WriteDate = DateTime.Now;
                    var t10 = repository.Update(model);
                    res.msg = result.Result.Msg;
                    logger.Info($"任务已停止:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = result.Result.Msg;
                    logger.Error($"任务停止异常:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
            }
            return res;
        }

        /// <summary>
        /// 恢复暂停任务
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <returns></returns>
        [Route("Resume/{id}")]
        [HttpPost]
        [PermissionFilter("Schedule.Stop")]
        public DataRes<bool> Resume(int id)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResSchedule>();
                //根据任务编号获取任务详情
                var model = repository.Get(id);
                //恢复指定任务
                var result = _schedulerCenter.ResumeJob(model.JobGroup, model.JobName);
                if (result.Result.Code == 1000)
                {
                    model.JobStatus = 1;
                    model.WriteDate = DateTime.Now;
                    var t10 = repository.Update(model);
                    res.msg = result.Result.Msg;
                    logger.Info($"任务已恢复:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = result.Result.Msg;
                    logger.Error($"任务恢复异常:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
            }
            return res;
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpPost]
        [PermissionFilter("Schedule.Delete")]
        public DataRes<bool> DeleteSchedule(int id)
        {
            var res = new DataRes<bool>() { code = ResCode.Success, data = true };
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResSchedule>();
                //根据任务编号获取任务详情
                var model = repository.Get(id);
                //恢复指定任务
                var result = _schedulerCenter.StopScheduleJob<ScheduleManage>(model.JobGroup, model.JobName);
                if (result.Result.Code == 1000)
                {
                    repository.Remove(model);
                    res.msg = result.Result.Msg;
                    logger.Info($"任务已删除:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = result.Result.Msg;
                    logger.Error($"任务停止异常,删除失败:{model.JobGroup}-{model.JobName},{result.Result.Msg}");
                }
            }
            return res;
        }

    }
}