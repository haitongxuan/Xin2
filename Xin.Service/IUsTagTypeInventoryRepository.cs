using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;

namespace Xin.Service
{
    public interface IUsTagTypeInventoryRepository
    {
        IEnumerable<UsTagTypeInventory> GetList(string filterStr = null);

        DataPage<UsTagTypeInventory> GetPage(int pageIndex, int pageSize, string filterStr = null);
    }
}
