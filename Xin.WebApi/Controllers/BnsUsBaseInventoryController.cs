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
    public class BnsUsBaseInventoryController : BaseController<BnsUsBaseInventory>
    {
        public BnsUsBaseInventoryController(IUowProvider uowProvider) : base(uowProvider)
        {
        }

        [HttpPost]
        [Route("import")]
        public async Task<ActionResult<DataRes<bool>>> Import(IFormFile excelFile)
        {
            DataRes<bool> result = new DataRes<bool>() { code = ResCode.Success, data = true };
            if (excelFile == null || excelFile.Length <= 0)
            {
                result.code = ResCode.Error;
                result.data = false;
                result.msg = ResMsg.FileNotNull;
            }
            else if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                result.code = ResCode.NoValidate;
                result.msg = ResMsg.ExcelNotValidate;
                result.data = false;

            }
            var list = new List<BnsUsBaseInventory>();
            using (var stream = new MemoryStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 2; row < rowCount; row++)
                    {
                        var model = new BnsUsBaseInventory();
                        model.ProductSku = worksheet.Cells[row, 1].Value.ToString();
                        var qty = worksheet.Cells[row, 2].Value.ToString();
                        if (string.IsNullOrEmpty(qty))
                            model.Qty = 0;
                        else
                            model.Qty = int.Parse(qty);
                        var warehouseId = worksheet.Cells[row, 3].Value.ToString();
                        model.WarehouseId = int.Parse(warehouseId == null ? "21" : warehouseId);
                        var tagType = worksheet.Cells[row, 4].Value.ToString();
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
                }
            }
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<BnsUsBaseInventory>();
                await repository.BulkInsertAsync(list).ConfigureAwait(false);
            }
            return result;
        }
    }
}
