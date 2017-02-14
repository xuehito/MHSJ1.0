using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web.CodeCommon
{
    /// <summary>
    /// QueryFrom 的摘要说明
    /// </summary>
    public class QueryFrom : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var sb = new StringBuilder();
            string name = context.Request["name"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name)) return;

            var list = FromManager.GetFromList(name);

            sb.Append("{\"from\":[");

            if (list.Count == 0) return;
            int i = 0;
            foreach (T_From item in list)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("{\"name\":\"" + item.FromName + "\"");
                sb.Append(",\"id\":\"" + item.FromId + "\"");
                sb.Append("}");
                i++;
            }

            sb.Append("]}");

            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}