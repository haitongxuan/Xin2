using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.Service
{
    public class ECWarehouseRepository :
        Repository.EntityRepositoryBase<Context.XinDBContext, Entities.ECWarehouse>
    {
        public ECWarehouseRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

    }
}
