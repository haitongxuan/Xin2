using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.Web.Framework.Helper;
using Xin.Web.Framework.Model;

namespace Xin.WebApi.Controllers
{
    /// <summary>
    /// 钉钉小程序
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DingTalkNewsController : ControllerBase
    {
        private IUowProvider _uowProvider;
        private readonly IHostingEnvironment _hostingEnvironment;
        public DingTalkNewsController(IHostingEnvironment hostingEnvironment, IUowProvider uowProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            var config = new AppConfigurationServices().Configuration;
            _uowProvider = uowProvider;
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="picName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/picUpload")]
        public BaseResponse UploadPic([FromForm] IFormFile picName)
        {
            var res = new BaseResponse();
            res = Web.Framework.Helper.FileHelper.upload(picName, res, _hostingEnvironment.ContentRootPath);
            return res;
        }
        /// <summary>
        /// 获取新闻分类
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/GetTypes")]
        public GridPage<List<DingClassify>> GetTypes(DatetimePointPageReq pageReq)
        {
            var res = new GridPage<List<DingClassify>>() { code = ResCode.Success };
            return DataBaseHelper<DingClassify>.GetList(_uowProvider, res, pageReq);
        }
        /// <summary>
        /// 根据分类ID获取新闻
        /// </summary>
        /// <param name="pageReq"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/GetNews")]
        public GridPage<List<DingNew>> GetNews(DatetimePointPageReq pageReq, int id)
        {
            var res = new GridPage<List<DingNew>>() { code = ResCode.Success };

            if (id != null)
            {
                FilterNode node = new FilterNode();
                node.andorop = "and";
                node.binaryop = "eq";
                node.key = "DingClassify.Id";
                node.value = id;
                if (pageReq == null)
                {
                    pageReq = new DatetimePointPageReq();
                }
                pageReq.query.Add(node);
                DingNew dd = new DingNew();
                res = DataBaseHelper<DingNew>.GetList(_uowProvider, res, pageReq);
            }
            else
            {
                res.code = ResCode.Error;
                res.msg = "类型不能为空";
            }
            return res;
        }
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="newsDetail"></param>
        /// <param name="classifyId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/addNews")]
        public GridPage<DingClassify> UploadPic([FromBody] DingNew newsDetail, int classifyId)
        {
            var ress = new GridPage<DingClassify>() { code = ResCode.Success };
            using (var mdReader = new StringReader(newsDetail.OriginalContent))
            {
                using (var html = new StringWriter())
                {
                    CommonMark.CommonMarkConverter.Convert(mdReader, html);
                    newsDetail.HtmlContent = html.ToString();
                }
            }
            ress = DataBaseHelper<DingClassify>.Get(_uowProvider, ress, classifyId, x => x.Include(a => a.DingNews));
            ress.data.DingNews.Add(newsDetail);
            ress = DataBaseHelper<DingClassify>.Create(_uowProvider, ress.data, ress, true);
            return ress;
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="classify"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/addTypes")]
        public GridPage<DingClassify> addTypes([FromBody] DingClassify classify)
        {
            var res = new GridPage<DingClassify>() { code = ResCode.Success };
            res = DataBaseHelper<DingClassify>.Create(_uowProvider, classify, res, true);
            return res;
        }
    }
}