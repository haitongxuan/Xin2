using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DingTalk.Api.Request;
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
        [Route("picUpload")]
        public BaseResponse UploadPic([FromForm] IFormFile picName)
        {
            var res = new BaseResponse();
            res = Web.Framework.Helper.FileHelper.uploadImage(picName, res, _hostingEnvironment.ContentRootPath);
            return res;
        }

        /// <summary>
        /// 根据分类ID获取新闻
        /// </summary>
        /// <param name="pageReq"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetNews")]
        public GridPage<List<DingNew>> GetNews(DatetimePointPageReq pageReq, int? id)
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
                res = DataBaseHelper<DingNew>.GetList(_uowProvider, res, pageReq, x => x.Include(a => a.DingClassify));
            }
            else
            {
                //all
                res = DataBaseHelper<DingNew>.GetList(_uowProvider, res, pageReq, x => x.Include(a => a.DingClassify));
            }
            return res;
        }
        /// <summary>
        /// 根据新闻ID获取新闻
        /// </summary>
        /// <param name="pageReq"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetNew")]
        public GridPage<DingNew> GetNew(int id)
        {
            var res = new GridPage<DingNew>() { code = ResCode.Success };
            var result = new GridPage<List<DingNew>>() { code = ResCode.Success };
            FilterNode node = new FilterNode();
            node.andorop = "and";
            node.binaryop = "eq";
            node.key = "Id";
            node.value = id;
            var pageReq = new DatetimePointPageReq();
            pageReq.query.Add(node);
            result = DataBaseHelper<DingNew>.GetList(_uowProvider, result, pageReq,x=>x.Include(a=>a.DingClassify));
            if (result.data.Count > 0)
            {
                res.data = result.data[0];
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
        [Route("addNews")]
        public GridPage<DingClassify> addNews([FromBody] DingNew newsDetail, int classifyId)
        {
            var ress = new GridPage<DingClassify>() { code = ResCode.Success };
            //using (var mdReader = new StringReader(newsDetail.OriginalContent))
            //{
            //    using (var html = new StringWriter())
            //    {
            //        CommonMark.CommonMarkConverter.Convert(mdReader, html);
            //        newsDetail.HtmlContent = html.ToString();
            //    }
            //}
            ress = DataBaseHelper<DingClassify>.Get(_uowProvider, ress, classifyId, x => x.Include(a => a.DingNews));
            ress.data.DingNews.Add(newsDetail);
            ress = DataBaseHelper<DingClassify>.Create(_uowProvider, ress.data, ress, true);
            if (newsDetail.Status == 1)
            {
                OapiMessageCorpconversationAsyncsendV2Request.MsgDomain obj1 = new OapiMessageCorpconversationAsyncsendV2Request.MsgDomain();
                obj1.Msgtype = "link";
                OapiMessageCorpconversationAsyncsendV2Request.LinkDomain obj2 = new OapiMessageCorpconversationAsyncsendV2Request.LinkDomain();
                obj2.PicUrl = newsDetail.Image;
                obj2.MessageUrl = "eapp://pages/detail/index?id=" + ress.data.Id;
                obj2.Text = newsDetail.SubTitle;
                obj2.Title = newsDetail.Title;
                obj1.Link = obj2;
                var res = DingTalkHelper.PushMessage("1814645351680963", null, "", obj1);
            }
            return ress;
        }

        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="newsDetail"></param>
        /// <param name="classifyId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("editNew")]
        public GridPage<DingNew> editNew([FromBody] DingNew newsDetail, int classifyId)
        {
            var res = new GridPage<DingClassify>() { code = ResCode.Success };
            var ress = new GridPage<DingNew>() { code = ResCode.Success };

            res = DataBaseHelper<DingClassify>.Get(_uowProvider, res, classifyId, x => x.Include(a => a.DingNews));
            var model = res.data.DingNews.Where(a => a.Id == newsDetail.Id).FirstOrDefault();
            if (model != null)
            {
                //model.Image = newsDetail.Image;
                //model.OriginalContent = newsDetail.OriginalContent;
                //model.Status = newsDetail.Status;
                //model.Title = newsDetail.Title;
                //model.UpdateTime = DateTime.Now;
                //model.HtmlContent = newsDetail.HtmlContent;
                //model.Editer = newsDetail.Editer;
                //model.SubTitle = newsDetail.SubTitle;
                newsDetail.DingClassify = res.data;
                newsDetail.CreateTime = model.CreateTime;
                newsDetail.UpdateTime = DateTime.Now;
                if (newsDetail.Status == 1)
                {
                    OapiMessageCorpconversationAsyncsendV2Request.MsgDomain obj1 = new OapiMessageCorpconversationAsyncsendV2Request.MsgDomain();
                    obj1.Msgtype = "link";
                    OapiMessageCorpconversationAsyncsendV2Request.LinkDomain obj2 = new OapiMessageCorpconversationAsyncsendV2Request.LinkDomain();
                    obj2.PicUrl = newsDetail.Image;
                    obj2.MessageUrl = "eapp://pages/detail/index?id=" + res.data.Id;
                    obj2.Text = newsDetail.SubTitle;
                    obj2.Title = newsDetail.Title;
                    obj1.Link = obj2;
                    var result = DingTalkHelper.PushMessage("1814645351680963", null, "", obj1);
                }
                ress = DataBaseHelper<DingNew>.Edit(_uowProvider, newsDetail, ress);
            }
            else
            {
                ress.code = ResCode.Error;
                ress.msg = "记录不存在";
            }

            return ress;
        }

        /// <summary>
        /// 获取新闻分类
        /// </summary>
        /// <param name="pageReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetTypes")]
        public GridPage<List<DingClassify>> GetTypes(DatetimePointPageReq pageReq,int classId)
        {
            FilterNode node = new FilterNode();
            node.andorop = "and";
            node.binaryop = "eq";
            node.key = "DingClass.Id";
            node.value = classId;
            pageReq.query.Add(node);
            var res = new GridPage<List<DingClassify>>() { code = ResCode.Success };
            return DataBaseHelper<DingClassify>.GetList(_uowProvider, res, pageReq);
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="classify"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addTypes")]
        public GridPage<DingClassify> addTypes([FromBody] DingClassify classify,int classId)
        {
            var res = new GridPage<DingClassify>() { code = ResCode.Success };
            var ress = new GridPage<DingClass>() { code = ResCode.Success };

            ress = DataBaseHelper<DingClass>.Get(_uowProvider, ress, classId);
            if (ress.data!=null)
            {
                classify.DingClass = ress.data;
            }
            res = DataBaseHelper<DingClassify>.Create(_uowProvider, classify, res, true);
            return res;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deleteTypes")]
        public GridPage<DingClassify> deleteTypes(int id)
        {
            var res = new GridPage<DingClassify>() { code = ResCode.Success };
            res = DataBaseHelper<DingClassify>.Delete(_uowProvider, id, res);
            return res;
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateTypes")]
        public GridPage<DingClassify> updateTypes([FromBody] DingClassify id)
        {
            var res = new GridPage<DingClassify>() { code = ResCode.Success };
            res = DataBaseHelper<DingClassify>.Edit(_uowProvider, id, res);
            return res;
        }
    }
}