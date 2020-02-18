using Microsoft.EntityFrameworkCore;

namespace Xin.Repository
{
    public interface IRepositoryInjection
    {
        IRepositoryInjection SetContext(DbContext context);
    }
}