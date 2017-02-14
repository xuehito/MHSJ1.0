using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Core.Common;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web
{
    public partial class index : Pager
    {
        public string Keyword;
        public int QueryType;    
        public string Direction;
        public string Fr1;
        public string Fr2;
        public string Fr3;
        public string Fr4;
        public string Fr5;
        public string Fr6;
        public string Froms;

        public string List;

        public int PageSize = 250;
        public string Pager; //分页
        public string Writers;
        public string Xiangqing;

        public string Jianti { get; set; }
        public string Pinyin { get; set; }
        public string Tongjia { get; set; }
        public string Fanti { get; set; }
        public string Yiti { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Query();
        }

        private bool CheckQuery(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return false;

            return true;
        }

        private void Query()
        {
            string keyword = StringHelper.CutString(StringHelper.SqlEncode(RequestHelper.QueryString("keyword")), 1);
            string writers = RequestHelper.QueryString("writer");
            string queryType = RequestHelper.QueryString("querytype");
            string froms = RequestHelper.QueryString("from");
            string direction1 = RequestHelper.QueryString("direction1");
            string direction2 = RequestHelper.QueryString("direction2");
            string fr1 = RequestHelper.QueryString("fr1[]");
            string fr2 = RequestHelper.QueryString("fr2[]");
            string fr3 = RequestHelper.QueryString("fr3[]");
            string fr4 = RequestHelper.QueryString("fr4[]");
            string fr5 = RequestHelper.QueryString("fr5[]");
            string fr6 = RequestHelper.QueryString("fr6[]");

            Keyword = keyword;
            QueryType =string.IsNullOrEmpty(queryType) ? 0: Convert.ToInt32(queryType);
            Writers = writers;
            Froms = froms;
            if (string.IsNullOrEmpty(direction1)) direction1 = "0";
            if (string.IsNullOrEmpty(direction2)) direction2 = "0";
            Direction = direction1 + "," + direction2;
            Fr1 = fr1;
            Fr2 = fr2;
            Fr3 = fr3;
            Fr4 = fr4;
            Fr5 = fr5;
            Fr6 = fr6;

            if (!CheckQuery(keyword)) return;

            var itemQuery = new V_Post
            {
                WriterName = writers,
                FromName = froms,
                WordDirection = Direction,
                WordType = fr1 + "," + fr2 + "," + fr3 + "," + fr4 + "," + fr5 + "," + "," + fr6
            };

            itemQuery.WordType = itemQuery.WordType.Trim(',');

            int totalRecord = 0;

            var listItem = Biz_PostManager.biz_post.GetPostList(PageSize, PageIndex, out totalRecord,keyword,QueryType, itemQuery);

            if (listItem.Count > 0)
            {
                Jianti = listItem[0].SimplifiedWord;
                Pinyin=listItem[0].Pinyin;
                Fanti=listItem[0].TraditionalWord;
                Yiti=listItem[0].Yiti;
                //    var strXq = new StringBuilder();
                //    strXq.Append("<div class='wtu'>");
                //    strXq.AppendFormat("<p class='xiangqing'><span>简体：</span>{0}(<span class='pinyin'>{1}</span>)</p>",
                //        listItem[0].SimplifiedWord,
                //        listItem[0].Pinyin);
                //    strXq.AppendFormat("<p><span>通假：</span>{0}</p>", listItem[0].Tongjia);
                //    strXq.AppendFormat("<p class='xiangqing'><span>繁体：</span>{0}</p>", listItem[0].TraditionalWord);
                //    strXq.AppendFormat("<p><span>异体：</span>{0}</p>", listItem[0].Yiti);
                //    strXq.Append("</div>");

                //    Xiangqing = strXq.ToString();
            }

            var strList = new StringBuilder();
            strList.Append("<div class='wtu'>");
            strList.Append("<ul>");
            if (listItem.Count > 0)
            {
                foreach (V_Post item in listItem)
                {
                    string imgUrl = null;
                    if (!string.IsNullOrEmpty(item.ImageUrl)) imgUrl = item.ImageUrl.Split('/')[3].Split('.')[0];

                    strList.AppendFormat("<li title='{0}'>", imgUrl);
                    strList.AppendFormat("<div><img class='lazy' data-original='{0}' alt='{1}' draggable='false'/></div>", item.ImageUrl,
                        imgUrl);
                    strList.AppendFormat("<div><p><span style='color:#8e0528'>{2}</span>.{0}.{1}</p></div>", item.WriterName, item.FromName, item.Tword);
                    strList.Append("</li>");
                }
            }
            else
            {
                strList.Append("<p style='text-align: center'>没有查到内容，换个条件试试( ⊙ o ⊙ )</p>");
            }
            strList.Append("</ul>");
            strList.Append("</div>");

            List = strList.ToString();

            string url = string.Empty;
            if (!string.IsNullOrEmpty(Keyword)) url += string.Format("&keyword={0}", Keyword);
            if (!string.IsNullOrEmpty(Keyword)) url += string.Format("&queryType={0}", QueryType);
            if (!string.IsNullOrEmpty(Writers)) url += string.Format("&writer={0}", Writers);
            if (!string.IsNullOrEmpty(Froms)) url += string.Format("&from={0}", Froms);
            if (!string.IsNullOrEmpty(Direction)) url += string.Format("&direction={0}", Direction);
            if (!string.IsNullOrEmpty(Fr1)) url += string.Format("&fr1[]={0}", Fr1);
            if (!string.IsNullOrEmpty(Fr2)) url += string.Format("&fr2[]={0}", Fr2);
            if (!string.IsNullOrEmpty(Fr3)) url += string.Format("&fr3[]={0}", Fr3);
            if (!string.IsNullOrEmpty(Fr4)) url += string.Format("&fr4[]={0}", Fr4);
            if (!string.IsNullOrEmpty(Fr5)) url += string.Format("&fr5[]={0}", Fr5);
            if (!string.IsNullOrEmpty(Fr6)) url += string.Format("&fr6[]={0}", Fr6);

            Pager = CreateHtml(PageSize, totalRecord, "index.aspx?page={0}" + url);
        }
    }
}