using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common;
using static DingTalk.Api.Request.OapiMessageCorpconversationAsyncsendV2Request;

namespace Xin.Web.Framework.Helper
{
    public static class DingTalkHelper
    {
        private static IConfiguration config = new AppConfigurationServices().Configuration;

        private static string AppKey = config["DingTalk:AppKey"];
        private static string Appsecret = config["DingTalk:Appsecret"];
        private static long? AgentId = long.Parse(config["DingTalk:AgentId"]);

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public static OapiGettokenResponse getToken()
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest req = new OapiGettokenRequest();
            req.Appkey = AppKey;
            req.Appsecret = Appsecret;
            req.SetHttpMethod("GET");
            OapiGettokenResponse rsp = client.Execute(req);
            return rsp;
        }

        public static OapiMessageCorpconversationAsyncsendV2Response PushMessage(string userIdList,bool? toAllUser,string detptIdList,MsgDomain msg_)
        {
            OapiGettokenResponse token = getToken();
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2");
            OapiMessageCorpconversationAsyncsendV2Request req = new OapiMessageCorpconversationAsyncsendV2Request();
            req.UseridList = userIdList;
            req.ToAllUser = toAllUser;
            req.DeptIdList = detptIdList;
            req.Msg_ = msg_;
            req.AgentId = AgentId;
            OapiMessageCorpconversationAsyncsendV2Response rsp = client.Execute(req, token.AccessToken);
            return rsp;
        }

    }
}
