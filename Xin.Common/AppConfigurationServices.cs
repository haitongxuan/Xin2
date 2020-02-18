using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Xin.Common
{
    public class AppConfigurationServices
    {
        public IConfiguration Configuration { get; set; }
        public AppConfigurationServices()
        {

            var currentDir = Directory.GetCurrentDirectory();
            //ReloadOnChange = true 当appsettings.json被修改时重新加载        
            Configuration = new ConfigurationBuilder().AddJsonFile($"{currentDir}/appsettings.json", false, true).Build();
        }
    }
}
