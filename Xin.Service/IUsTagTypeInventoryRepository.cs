using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;

namespace Xin.Service
{
    public interface IUsTagTypeInventoryRepository
    {
        IEnumerable<UsTagTypeInventory> GetList(string filterStr = null);

        IEnumerable<UsTagTypeInventory> GetPage(int pageIndex, int pageSize, string filterStr = null);
    }
}
