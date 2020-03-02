using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Xin.Service
{
    public interface IXinRepository<TEntity>
    {
        /// <summary>
        /// 获取实体代号
        /// </summary>
        /// <returns></returns>
        Task<string> GetCodeAsync();

        string GetCode();

        void Add(TEntity entity);
    }
}
