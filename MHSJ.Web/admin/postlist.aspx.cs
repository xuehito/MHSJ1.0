using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MHSJ.Core.Common;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;
using MHSJ.Entity.Common;

namespace MHSJ.Web.admin
{
    public partial class admin_postlist : AdminPage
    {
        /// <summary>
        /// postid
        /// </summary>
        protected int PostId = RequestHelper.QueryInt("postid");

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("作品管理");

            if (Operate == OperateType.Delete)
            {
                Delete();
            }

            if (!IsPostBack)
            {
                LoadDefaultData();

                BindPostList();
            }

            ShowResult();
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        protected void ShowResult()
        {
            int result = RequestHelper.QueryInt("result");
            switch (result)
            {
                case 1:
                    ShowMessage("添加成功!");
                    break;
                case 2:
                    ShowMessage("修改成功!");
                    break;
                case 3:
                    ShowMessage("删除成功!");
                    break;
                case 444:
                    ShowMessage("权限不够!");
                    break;
                default:
                    break;
            }
        }

        protected void Delete()
        {
            T_Post post = Biz_PostManager.biz_post.GetSinglePost(new T_Post(){PostId = PostId});
            if (post == null)
            {
                return;
            }
            if (PageUtils.CurrentUser.Type != (int)UserType.Administrator)
            {
                Response.Redirect("postlist.aspx?result=444");
            }

            Biz_PostManager.biz_post.DeletePost(post.PostId);

            Response.Redirect("postlist.aspx?result=3");
        }

        protected string GetImage(object url,object writer)
        {
            string t = " <img src=" + url + " style='width: 90px;height: 100px;'/>";
           
            return t;
        }

        protected string GetEditLink(object postId, object userId)
        {

            string t = " <a href=\"postedit.aspx?operate=update&postid=" + postId + "\">编辑</a>";
            //if (Convert.ToInt32(userId) == PageUtils.CurrentUser.UserId || PageUtils.CurrentUser.Type == (int)UserType.Administrator)
            //{
                return t;
            //}
            //return string.Empty;
        }

        protected string GetDeleteLink(object postId, object userId)
        {

            string t = " <a href=\"postlist.aspx?operate=delete&postid=" + postId + "\" onclick=\"return confirm('确定要删除吗?');\">删除</a>";
            //if (Convert.ToInt32(userId) == PageUtils.CurrentUser.UserId || PageUtils.CurrentUser.Type == (int)UserType.Administrator)
            //{
                return t;
            //}
            //return string.Empty;
        }


        /// <summary>
        /// 加载默认数据
        /// </summary>
        private void LoadDefaultData()
        {
            //TODO 默认数据
        }

        /// <summary>
        /// 绑定
        /// </summary>
        protected void BindPostList()
        {
            string sw = RequestHelper.QueryString("simplifiedWord");
            string tw = RequestHelper.QueryString("traditionalWord");
            var writers = RequestHelper.QueryString("writer");
            var froms = RequestHelper.QueryString("from");
            var wordTypeName = RequestHelper.QueryString("wordTypeName");
            var wordDirection = RequestHelper.QueryString("wordDirection");
            var bushou = RequestHelper.QueryString("bushou");
            var state = RequestHelper.QueryString("state").ToString() == "" ? -1 : Convert.ToInt32(RequestHelper.QueryString("state"));
            var state1 = RequestHelper.QueryString("state1").ToString() == "" ? -1 : Convert.ToInt32(RequestHelper.QueryString("state1"));

            txtSimplifiedWord.Text = sw;
            txtTraditionalWord.Text = tw;
            txtBushou.Text = bushou;
            txtWriterName.Text = writers;
            txtFromName.Text = froms;
            txtWordTypeName.Text = wordTypeName;
            HidRadioWordDirection.Value = wordDirection;
            State.Checked = state == 1;
            State1.Checked = state1 == 1;

            var itemQuery = new V_Post
            {
                SimplifiedWord = sw,
                TraditionalWord = tw,
                Bushou = bushou,
                WriterName = writers,
                FromName = froms,
                WordTypeName = wordTypeName,
                WordDirection = wordDirection,
                State = state
            };
            if (state ==  state1)
            {
                itemQuery.State = -1;
            }
            else if (state == 1)
            {
                itemQuery.State = 1;
            }
            else if (state == 0)
            {
                itemQuery.State = 0;
            }
            
            int totalRecord = 0;

            List<V_Post> list = Biz_PostManager.QueryList(itemQuery, Pager1.PageSize, Pager1.PageIndex, out totalRecord);
            rptPost.DataSource = list;
            rptPost.DataBind();
            Pager1.RecordCount = totalRecord;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sw = StringHelper.UrlEncode(txtSimplifiedWord.Text);
            string tw = StringHelper.UrlEncode(txtTraditionalWord.Text);
            string writer = StringHelper.UrlEncode(txtWriterName.Text);
            string from = StringHelper.UrlEncode(txtFromName.Text);
            string wordTypeName = StringHelper.UrlEncode(txtWordTypeName.Text);
            string wrdDirection = StringHelper.UrlEncode(RadioWordDirection.Text);
            string bushou = StringHelper.UrlEncode(txtBushou.Text);
            int state = State.Checked ? 1 : 0;
            int state1 = State1.Checked ? 1 : 0;

            Response.Redirect(string.Format("postlist.aspx?simplifiedWord={0}&traditionalWord={1}&writer={2}&from={3}&wordTypeName={4}&wordDirection={5}&bushou={6}&state={7}&state1={8}", sw, tw, writer, from, wordTypeName, wrdDirection, bushou, state, state1));
            //Response.Redirect(string.Format("postlist.aspx?simplifiedWord={0}&traditionalWord={1}&writer={2}&from={3}&wordTypeName={4}&wordDirection={5}&bushou={6}", sw, tw, writer, from, wordTypeName, wrdDirection, bushou));
        }

        //转换
        public string WordTypeTransForm(string type)
        {
            switch (type)
            {
                case "1": return "大楷";
                case "2": return "小楷";
                case "3": return "魏碑";
                case "4": return "其他";//"摩崖";
                case "5": return "行楷";
                case "6": return "行书";
                case "7": return "大草";
                case "8": return "小草";
                case "9": return "章草";
                case "10": return "汉隶";
                case "11": return "简牍";
                case "12": return "摩崖";
                case "13": return "明清";
                case "14": return "大篆";
                case "15": return "小篆";
                case "16": return "甲骨";
                case "17": return "中山";
                //case "18": return "汗篆";
                case "19": 
                    return "端瓦";//return "端额";
                case "20": return "简帛";
                case "21": return "秦汉";
                case "22":
                    return "流派";//return "明清";
                case "23": return "鸟虫";
                case "24": return "园朱";
                case "25": return "玉篆";
                case "26": return "叠篆";
                case "27": return "钱币";
            }
            return null;
        }
    }
}