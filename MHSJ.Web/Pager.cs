using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Core.Service.Account;
using MHSJ.Core.Service.Link;
using MHSJ.Entity;

namespace MHSJ.Web
{
    /// <summary>
    ///     前台分页类
    /// </summary>
    public class Pager:Page
    {
        public static string Keywords;//Meta Keywords
        public static string Description; //Meta Description
        public static string Bottom; //页脚

        public static string SiteUrl = "http://www.mhsj.top/";
        //public static string IndexUrl = Url+"index.aspx";
       
        protected Pager()
        {
            QueryFoot();
        }

        /// <summary>
        ///     当前页
        /// </summary>
        public static int PageIndex
        {
            get { return RequestHelper.QueryInt("page", 1); }
        }


        public static string CreateHtml(int pageSize, int recordCount, string url)
        {
            string html = string.Empty;

            if (recordCount == 0)
            {
                return html;
            }

            int pageCount = recordCount / pageSize;


            if (recordCount % pageSize > 0)
            {
                pageCount += 1;
            }
            string total = string.Empty;
            string left = string.Empty;
            string right = string.Empty;
            string center = string.Empty;


            //显示首页 上一页
            if (PageIndex == 1)
            {
                left += "<p><span>首页</span></p>";
                left += "<p><span>上一页</span></p>";
            }
            else
            {
                left += "<p><a href=\"" + string.Format(url, 1) + "\">首页</a></p>";
                left += "<p><a href=\"" + string.Format(url, PageIndex - 1) + "\">上一页</a></p>";
            }

            //显示尾页 下一页
            if (PageIndex < pageCount && pageCount > 1)
            {
                right += "<p><a href=\"" + string.Format(url, PageIndex + 1) + "\">下一页</a></p>";
                right += "<p><a href=\"" + string.Format(url, pageCount) + "\">尾页</a></p>";
            }
            else
            {
                right += "<p><span>下一页</span></p>";
                right += "<p><span>尾页</span></p>";
            }

            int min = 1; //要显示的页面数最小值
            int max = pageCount; //要显示的页面数最大值

            if (pageCount > 5)
            {
                if (PageIndex > 2 && PageIndex < (pageCount - 1))
                {
                    min = PageIndex - 2;
                    max = PageIndex + 2;
                }
                else if (PageIndex <= 2)
                {
                    min = 1;
                    max = 5;
                }

                else if (PageIndex >= (pageCount - 1))
                {
                    min = pageCount - 4;
                    max = pageCount;
                }
            }


            //循环显示数字
            for (int i = min; i <= max; i++)
            {
                if (PageIndex == i) //如果是当前页，用粗体和红色显示
                {
                    center += "<p class='kuang'><span class=\"current\">" + i + "</span></p>";
                }
                else
                {
                    center += "<p class='kuang'><a href=\"" + string.Format(url, i) + "\">" + i + "</a></p>";
                }
            }

            //  total = string.Format("<span class=\"total\">共有<strong>{0}</strong>条</span>", recordCount);

            html = "<div  class= \"fanbtn\">";
            html += "<div>";
            html += (total + left + center + right);
            html += "</div>";
            html += "</div>";


            return html;
        }

        /// <summary>
        /// 获取脚部内容
        /// </summary>
        /// <returns></returns>
        public void QueryFoot()
        {
            var foot = SettingManager.GetSetting();
            Keywords = foot.MetaKeywords;
            Description = foot.MetaDescription;
            Bottom = foot.FooterHtml;
        }

        /// <summary>
        /// 获取所有友链
        /// </summary>
        public string QueryLink()
        {
            var linklist = Biz_LinkManager.biz_link.QueryList();

            var str = new StringBuilder();
            str.Append("<ul>");
            foreach (var link in linklist)
            {
                str.Append("<li>");
                str.AppendFormat("<a target='_blank' href='{0}' title='{1}'>{1}</a>", link.Url, link.Name);
                str.Append("</li>");
            }
            str.Append("</ul>");

            return str.ToString();
        }
    }
}