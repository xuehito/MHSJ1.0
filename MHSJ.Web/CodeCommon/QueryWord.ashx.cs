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
    /// 模糊查询汉字
    /// </summary>
    public class QueryWord : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var sb = new StringBuilder();

            var name = context.Request["name"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name)) return;

            var list = Biz_WordManager.GetWriterList(name.Trim());

            sb.Append("{\"words\":[");

            if (list.Count == 0) return;
            int i = 0;
            foreach (T_Word item in list)
            {
                if(i>=5) break;

                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("{\"word\":\"" + item.SimplifiedWord + "\"");
                sb.Append(",\"tword\":\"" + item.TraditionalWord + "\"");
                sb.Append(",\"bsword\":\"" + item.Bushou + "\"");
                sb.Append(",\"id\":\"" + item.WordId + "\"");
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