using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xin.Common.Model;

namespace Xin.Common.Model
{
    public class PageDataReq
    {
        //  int pageNum = 1, int pageSize = 20, string field = "id", string order = " desc "
        public int pageNum { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public string order { get; set; }

        public List<ConditionNode> query { get; set; }
    }

}
