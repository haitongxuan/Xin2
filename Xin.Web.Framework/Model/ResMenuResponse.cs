using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities;

namespace Xin.Web.Framework.Model
{
    public class ResMenuResponse
    {
        public ResMenuResponse()
        {
            Children = new List<ResMenuResponse>();
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string path { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string component { get; set; }
        [JsonIgnore]
        public int? parentId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public Meta meta { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public List<ResMenuResponse> Children { get; set; }

    }
    public class Meta
    {
        public Meta(string title, string beforeCloseName, string icon, string access, bool? hideInBread, bool? hideInMenu, bool? notCache)
        {
            this.title = title;
            this.beforeCloseName = beforeCloseName;
            this.icon = icon;
            this.access = access;
            this.hideInBread = hideInBread;
            this.hideInMenu = hideInMenu;
            this.notCache = notCache;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string beforeCloseName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string icon { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string access { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public bool? hideInBread { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public bool? hideInMenu { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public bool? notCache { get; set; }

    }
}
