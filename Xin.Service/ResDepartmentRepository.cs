using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.Service
{
    public class ResDepartmentRepository :
        Repository.EntityRepositoryBase<Context.XinDBContext, Entities.ResDepartment>,
        IResDepartmentRepository
    {
        public ResDepartmentRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

        public string GetCode<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
