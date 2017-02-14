using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web
{
    /// <summary>
    /// 模糊查询作者
    /// </summary>
    public class QueryWriter : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            var sb = new StringBuilder();

            var name = context.Request["name"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name)) return;

            var list = WriterManager.GetWriterList(name.Trim());

            sb.Append("{\"writer\":[");

            if (list.Count == 0) return;
            int i = 0;
            foreach (T_Writer item in list)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("{\"name\":\"" + item.WriterName + "\"");
                sb.Append(",\"id\":\"" + item.Id + "\"");
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