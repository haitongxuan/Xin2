using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.Service
{
    public class ResDepartmentRepository :
        AutocodeBaseRepository<ResDepartment>,
        IResDepartmentRepository
    {
        public ResDepartmentRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }
    }
}
