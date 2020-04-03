using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xin.Entities;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Helper
{
    public class TreeHelper
    {

        public static List<ResMenuResponse> ToTree(List<ResMenuResponse> orignList,int? parentId = null)
        {
            List<ResMenuResponse> list = null;
            var children = orignList.Where(a => a.parentId == parentId).ToList();
            if (children.Count>0)
            {
                list = new List<ResMenuResponse>();

                foreach (var item in children)
                {
                    item.Children = ToTree(orignList, item.id);
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<ResMenuResponse> ToTreeResponse(List<ResMenu> resssss)
        {
            List<ResMenuResponse> list = new List<ResMenuResponse>();
            foreach (var item in resssss)
            {
                ResMenuResponse temp = new ResMenuResponse();
                temp.id = item.Id;
                temp.component = item.Component;
                temp.name = item.Name;
                temp.path = item.Url;
                temp.parentId = null;
                if (item.Parent!=null)
                {
                    temp.parentId=item.Parent.Id;
                }
                Meta meta = new Meta(item.Title,item.BeforeCloseName,item.Icon,item.Access,item.HideInBread,item.HideInMenu,item.NotCache);
                temp.meta = meta;
                list.Add(temp);
            }
            return list;
        }
    }
}
