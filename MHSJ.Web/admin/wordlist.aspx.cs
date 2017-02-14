using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MHSJ.Core.Common;
using MHSJ.Core.Service.Admin;
using MHSJ.Data.Admin;
using MHSJ.Data.Common;
using MHSJ.Entity;
using MHSJ.Entity.Common;

namespace MHSJ.Web.admin
{
    public partial class wordlist  : AdminPage
    {
        /// <summary>
        ///     PostId
        /// </summary>
        protected int PostId = RequestHelper.QueryInt("PostId");

        /// <summary>
        ///     修改时提示
        /// </summary>
        protected string PasswordMessage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("文字管理");

            if (!IsPostBack)
            {
                BindWriterList();

                if (Operate == OperateType.Update)
                {
                    BindWriter();
                    btnEdit.Text = "修改";
                    //txtSimplifiedWord.Enabled = false;

                    PasswordMessage = "(不修改请留空)";
                }
                else if (Operate == OperateType.Delete)
                {
                    DeleteWord();
                }
            }

            ShowResult();

            var action=RequestHelper.QueryString("action");
            if (action == "word")
            {
                return;
                
                UpdatePost();
            }
            if (action == "Tword")
            {
                return;

                UpdateTWord();
            }
        }

        /// <summary>
        /// 导入对应文字
        /// </summary>
        /// <returns></returns>
        public bool UpdatePost()
        {
            var i = 0;
            var list = Biz_WordManager.QueryList();

            foreach (var li in list)
            {
                var item = new T_Post();
                item.SimplifiedWord = li.SimplifiedWord;
                List<T_Post> postList = Biz_PostManager.QueryList(item);

                foreach (var post in postList)
                {

                    var info = new T_Post();
                    info.PostId = post.PostId;

                    info = Biz_PostManager.biz_post.GetSinglePost(info);
                    info.Word = li.SimplifiedWord;
                    info.WordId = li.WordId;

                    Biz_PostManager.biz_post.UpdatePost(info);

                    i++;
                }
            }
            ShowError("共导入"+i+"数据");
            return true;
        }

        /// <summary>
        /// 导入对应繁体
        /// </summary>
        /// <returns></returns>
        public bool UpdateTWord()
        {
            var i = 0;
            var list = Biz_PostManager.QueryList(new T_Post());

            foreach (var post in list)
            {
                var info = new T_Post();
                info.PostId = post.PostId;
                info.TWord = post.TraditionalWord;

                Biz_PostManager.biz_post.UpdatePost(info);

                i++;
            }
            ShowError("共导入" + i + "数据");
            return true;
        }

        /// <summary>
        ///     显示结果
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
                //case 4:
                //    ShowError("不能删除自己!");
                //    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     绑定实体
        /// </summary>
        protected void BindWriter()
        {
            T_Word p = Biz_WordManager.GetSingleWord(PostId);
            if (p != null)
            {
                txtSimplifiedWord.Text = StringHelper.HtmlDecode(p.SimplifiedWord);
                txtTraditionalWord.Text = p.TraditionalWord;
                //txtPinyin.Text = p.Pinyin;
                //txtWubi.Text = p.Wubi;
                //txtChangjei.Text = p.Changjei;
                //txtZhengma.Text = p.Zhengma;
                txtBushou.Text = p.Bushou;
                //txtTongjia.Text = p.Tongjia;
                //txtYiti.Text = p.Yiti;
                State.Checked = p.State == 1;
            }
        }

        /// <summary>
        ///     绑定列表
        /// </summary>
        protected void BindWriterList()
        {
            string sw = RequestHelper.QueryString("simplifiedWord");
            string tw = RequestHelper.QueryString("traditionalWord");
            var bushou = RequestHelper.QueryString("bushou");
            var state = RequestHelper.QueryString("state").ToString() == "" ? -1 : Convert.ToInt32(RequestHelper.QueryString("state"));
            var state1 = RequestHelper.QueryString("state1").ToString() == "" ? -1 : Convert.ToInt32(RequestHelper.QueryString("state1"));

            querySimplifiedWord.Text = sw;
            queryTraditionalWord.Text = tw;
            queryBushou.Text = bushou;
            CheckBox1.Checked = state == 1;
            State1.Checked = state1 == 1;

            var itemQuery = new T_Word()
            {
                SimplifiedWord = sw,
                TraditionalWord = tw,
                Bushou = bushou,
               //Pinyin = txtPinyin
                State = state
            };
            if (state ==state1)
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
            Pager1.PageSize = 22;

            List<T_Word> list = Biz_WordManager.QueryList(itemQuery, Pager1.PageSize, Pager1.PageIndex, out totalRecord);
            rptWord.DataSource = list;
            rptWord.DataBind();
            Pager1.RecordCount = totalRecord;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sw = StringHelper.UrlEncode(querySimplifiedWord.Text);
            string tw = StringHelper.UrlEncode(queryTraditionalWord.Text);
            string bushou = StringHelper.UrlEncode(queryBushou.Text);
            int state = CheckBox1.Checked ? 1 : 0;
            int state1 = State1.Checked ? 1 : 0;

            Response.Redirect(string.Format("wordlist.aspx?simplifiedWord={0}&traditionalWord={1}&bushou={2}&state={3}&state1={4}", sw, tw, bushou, state, state1));
        }

        protected string GetEditLink(object postId, object userId)
        {

            string t = " <a href=\"wordlist.aspx?operate=update&postid=" + postId + "\">编辑</a>";
            //if (Convert.ToInt32(userId) == PageUtils.CurrentUser.UserId || PageUtils.CurrentUser.Type == (int)UserType.Administrator)
            //{
            return t;
            //}
            //return string.Empty;
        }

        protected string GetDeleteLink(object postId, object userId)
        {

            string t = " <a href=\"wordlist.aspx?operate=delete&postid=" + postId + "\" onclick=\"return confirm('确定要删除吗?');\">删除</a>";
            //if (Convert.ToInt32(userId) == PageUtils.CurrentUser.UserId || PageUtils.CurrentUser.Type == (int)UserType.Administrator)
            //{
            return t;
            //}
            //return string.Empty;
        }

        /// <summary>
        ///     删除汉字
        /// </summary>
        protected void DeleteWord()
        {
            //if (PostId == PageUtils.CurrentUserId)
            //{
            //    Response.Redirect("wordlist.aspx?result=4");
            //}
            var word = Biz_WordManager.GetSingleWord(PostId);
            if (word == null)
            {
                return;
            }
            if (PageUtils.CurrentUser.Type != (int)UserType.Administrator)
            {
                Response.Redirect("wordlist.aspx?result=4");
            }
            Biz_WordManager.DeleteWord(PostId);
            Response.Redirect("wordlist.aspx?result=3");
        }

        /// <summary>
        ///     编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var w = new T_Word();
            if (Operate == OperateType.Update)
            {
                w = Biz_WordManager.GetSingleWord(PostId);
            }
            else
            {
                w.CreateDate = DateTime.Now;
            }
            w.SimplifiedWord = txtSimplifiedWord.Text.Trim();
            if (string.IsNullOrEmpty(w.SimplifiedWord))
            {
                ShowError("请输入简体!");
                return;
            }
            w.TraditionalWord = txtTraditionalWord.Text.Trim();
            if (string.IsNullOrEmpty(w.TraditionalWord))
            {
                ShowError("请输入繁体!");
                return;
            }
            //w.Pinyin = txtPinyin.Text.Trim();
            //w.Wubi = txtWubi.Text.Trim();
            //w.Changjei = txtChangjei.Text.Trim();
            //w.Zhengma = txtZhengma.Text.Trim();
            w.State = State.Checked ? 1 : 0; ;
            w.Bushou = txtBushou.Text.Trim();
            //p.Tongjia = txtTongjia.Text.Trim();
            //p.Yiti = txtYiti.Text.Trim();
            w.UpdateDate = DateTime.Now;

            if (Operate == OperateType.Update)
            {
                Biz_WordManager.biz_word.UpdateWord(w);
                Response.Redirect("wordlist.aspx?result=2");
            }
            else
            {
                if (Biz_WordManager.biz_word.ExistsWord(w.TraditionalWord))
                {
                    ShowError("该字形已存在,请换之");
                    return;
                }

                if (Biz_WordManager.biz_word.InsertWord(w))
                {
                    Response.Redirect("wordlist.aspx?result=1");    
                }
                
            }
        }
    }
}