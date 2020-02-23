using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.Response
{
    public abstract class BaseResponse : ECResponseBody
    {
        public BaseResponse(ECResponseBody body)
        {
            this.Code = body.Code;
            this.Data = body.Data;
            this.Error = body.Error;
            this.Message = body.Message;
            this.Page = body.Page;
            this.PageSize = body.PageSize;
            this.ResponseTime = body.ResponseTime;
            this.Service = body.Service;
            this.TotalCount = body.TotalCount;
        }

        public string GetErrorString()
        {
            string result = "";
            foreach (var e in Error)
            {
                result = "\t" + e.ToString() + "\r\n";
            }
            return result;
        }
    }

}
