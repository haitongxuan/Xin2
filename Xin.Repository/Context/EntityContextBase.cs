using Microsoft.EntityFrameworkCore;

namespace Xin.Repository
{
    public class EntityContextBase<TContext> : DbContext, IEntityContext where TContext : DbContext
    {
        public EntityContextBase()
        {
        }

        public EntityContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }
    }
}
