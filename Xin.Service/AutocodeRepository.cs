using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xin.Common.CustomAttribute;
using Xin.Repository;
using Xin.Service.Context;

namespace Xin.Service
{
    public class AutocodeBaseRepository<TEntity> :
        EntityRepositoryBase<XinDBContext, TEntity>,
        IXinRepository<TEntity> where TEntity : class, new()
    {
        public AutocodeBaseRepository(XinDBContext context) : base(context)
        {
        }

        public AutocodeBaseRepository(ILogger<DataAccess> logger, XinDBContext context) : base(logger, context)
        {
        }

        public override void Add(TEntity entity)        {
            
            Type entityType = typeof(TEntity);
            var codeatt = (AutoCodeAttribute)entityType.GetCustomAttributes(typeof(AutoCodeAttribute), true)[0];
            if (codeatt != null)
            {
                if (codeatt.AutoCode)
                {
                    string code = GetCode();
                    var property = entityType.GetProperty(codeatt.AutoCodePropertyName);
                    property.SetValue(entity, code);
                }
            }
            base.Add(entity);
        }

        public virtual async Task<string> GetCodeAsync()
        {
            try
            {
                var codeatt = (AutoCodeAttribute)typeof(TEntity).GetCustomAttributes(typeof(AutoCodeAttribute), true)[0];
                string code = string.Empty;
                var code2 = await Context.GetAutoCodeAsync(codeatt.FixHeader, codeatt.Length, code);
                string c = code2.Item1;
                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCode()
        {
            try
            {
                var codeatt = (AutoCodeAttribute)typeof(TEntity).GetCustomAttributes(typeof(AutoCodeAttribute), true)[0];
                string code = string.Empty;
                Context.GetAutoCode(codeatt.FixHeader, codeatt.Length, ref code);
                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
