using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xin.Repository;
using Xin.Service;
using Xin.Entities;
using Xin.Web.Framework.Controllers;
using Xin.Web.Framework.Model;
using System.IO;
using OfficeOpenXml;
using System.Text;

namespace Xin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BnsUsBaseInventoryController : ExcelImportController<BnsUsBaseInventory>
    {
        public BnsUsBaseInventoryController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        protected override List<BnsUsBaseInventory> GetEntitiesFromExcel(ExcelWorksheet sheet)
        {
            var list = new List<BnsUsBaseInventory>();
            int rowCount = sheet.Dimension.Rows;
            int colCount = sheet.Dimension.Columns;
            for (int row = 2; row < rowCount; row++)
            {
                var model = new BnsUsBaseInventory();
                model.ProductSku = sheet.Cells[row, 1].Value.ToString();
                var qty = sheet.Cells[row, 2].Value.ToString();
                if (string.IsNullOrEmpty(qty))
                    model.Qty = 0;
                else
                    model.Qty = int.Parse(qty);
                var warehouseId = sheet.Cells[row, 3].Value.ToString();
                model.WarehouseId = int.Parse(warehouseId == null ? "21" : warehouseId);
                var tagType = sheet.Cells[row, 4].Value.ToString();
                if (tagType == "unice")
                {
                    model.TagType = BnsUsTagType.Unice;
                }
                else
                {
                    model.TagType = BnsUsTagType.Normal;
                }
                list.Add(model);
            }
            return list;
        }
    }
}
