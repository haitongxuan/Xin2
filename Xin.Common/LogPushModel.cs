using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Common
{
   public class LogPushModel
    {
        public LogPushModel(string fromApp,string fromClass ,string leavel,string message,object parametrer)
        {
            this.FromApp = fromApp;
            this.FromClass = fromClass;
            this.Leavel = leavel;
            this.Message = message;
            this.Time = DateTime.Now;
            this.Parameter = JsonConvert.SerializeObject(parametrer);
        }
        public string FromApp { get; set; }
        public string FromClass { get; set; }

        public string Leavel { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Parameter { get; set; }
    }
}
