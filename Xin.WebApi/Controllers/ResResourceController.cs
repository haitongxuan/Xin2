using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Web.Framework;
using Xin.Entities;
using Xin.Repository;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResResourceController : XinVDPageBaseController<ResResource>
    {
        public ResResourceController(IUowProvider uowProvider, IDataPager<ResResource> dataPager) : base(uowProvider, dataPager)
        {
        }
    }
}