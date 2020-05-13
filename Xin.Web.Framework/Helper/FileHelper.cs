using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Helper
{
    public class FileHelper
    {
        public static BaseResponse uploadImage(IFormFile files, BaseResponse res,string path)
        {

            try
            {
                if (files.Length > 0)
                {

                    string fileExt = Path.GetExtension(files.FileName); //文件扩展名，不含“.”
                    string newFileName = System.Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                    var filePath = path + "/wwwroot/upload/images/";
                    if (!System.IO.Directory.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(path + "/upload");
                        System.IO.Directory.CreateDirectory(path + "/upload/images/");
                    }
                    using (var stream = System.IO.File.Create(filePath+ newFileName))
                    {

                        files.CopyTo(stream);
                        stream.Flush();
                    }
                    res.code = ResCode.Success;
                    res.msg = "成功";
                    var dic = new Dictionary<string, string>();
                    dic.Add("url", "/upload/images/" + newFileName);
                    res.data = dic;
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = "文件不能为空";
                }
            }
            catch (Exception ex)
            {

                res.code = ResCode.ServerError;
                res.msg = $"文件上传出现异常:{ex.Message}";
            }
            return res;
        }
        public static BaseResponse uploadExcel(byte[] bytes, BaseResponse res, string path)
        {

            try
            {
                if (bytes.Length > 0)
                {

                    string fileExt = ".xlsx"; //文件扩展名，不含“.”
                    string newFileName = System.Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                    var filePath = path + "/wwwroot/upload/excel/";
                    if (!System.IO.Directory.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(path + "/upload");
                        System.IO.Directory.CreateDirectory(path + "/upload/excel/");
                    }
                    using (var stream = System.IO.File.Create(filePath + newFileName))
                    {
                        var ss = new MemoryStream(bytes);
                        ss.CopyTo(stream);
                        stream.Flush();
                    }
                    res.code = ResCode.Success;
                    res.msg = "成功";
                    var dic = new Dictionary<string, string>();
                    dic.Add("url", "/upload/excel/" + newFileName);
                    res.data = dic;
                }
                else
                {
                    res.code = ResCode.Error;
                    res.msg = "文件不能为空";
                }
            }
            catch (Exception ex)
            {

                res.code = ResCode.ServerError;
                res.msg = $"文件上传出现异常:{ex.Message}";
            }
            return res;
        }
    }
}
