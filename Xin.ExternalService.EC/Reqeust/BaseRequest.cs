using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.ExternalService.EC.Response;

namespace Xin.ExternalService.EC.Reqeust
{
    public abstract class BaseRequest<T> where T : BaseResponse
    {
        protected ECService service { get; set; }
        public BaseRequest(string username, string password)
        {
            this.service = new ECService(username, password);
            service.Username = username;
            service.Password = password;
        }

        public abstract Task<T> Request();
    }
}
