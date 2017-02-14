using System.Text;
using System.Web;
using MHSJ.Core.Common;

namespace MHSJ.Web.CodeCommon
{
    /// <summary>
    ///     ChineseStringConverter 的摘要说明
    /// </summary>
    public class ChineseStringConverter : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var sb = new StringBuilder();
            string name = context.Request["name"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name)) return;

            string tword = NetHelper.ChineseStringConverter.SimplifiedToTraditional(name);
            string pinyin = NetHelper.GetPinyin(name);
            //sb.Append("{\"word\":[");

            sb.Append("{\"jian\":\"" + name + "\"");
            sb.Append(",\"fan\":\"" + tword + "\"");
            sb.Append(",\"pinyin\":\"" + pinyin + "\"");
            sb.Append("}");

            //sb.Append("]}");

            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}