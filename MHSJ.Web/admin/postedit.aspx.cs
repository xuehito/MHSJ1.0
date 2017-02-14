using System;
using System.Web.UI.WebControls;
using MHSJ.Core.Common;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;
using MHSJ.Entity.Common;

namespace MHSJ.Web.admin
{
    public partial class admin_postedit : AdminPage
    {
        /// <summary>
        ///     提示
        /// </summary>
        protected int Message = RequestHelper.QueryInt("message", 0);

        /// <summary>
        ///     ID
        /// </summary>
        protected int PostId = RequestHelper.QueryInt("postid", 0);

        protected string headerTitle = "添加作品";

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("添加作品");
            
            if (!IsPostBack)
            {
                txtWord.Attributes.Add("readonly", "true");

                if (Operate == OperateType.Update)
                {
                    BindPost();
                    headerTitle = "修改作品";
                    btnEdit.Text = "修改";
                    SetPageTitle("修改作品");
                    switch (Message)
                    {
                        case 1:
                            ShowMessage("添加成功!");
                            break;
                        case 2:
                            ShowMessage("修改成功!");
                            break;
                    }
                }
                else
                {
                    var post = PostManager.GetLastPost();
                    HidRadioList.Value = post.WordType;
                    HidRadioWordDirection.Value = post.WordDirection;

                    txtWriter.Text = post.WriterName;
                    HidWriterId.Value = post.WriterId.ToString();
                    txtFrom.Text = post.FromName;
                    HidFromId.Value = post.FromId.ToString();
                }
            }
        }

        /// <summary>
        ///     绑定实体
        /// </summary>
        protected void BindPost()
        {
            var p = Biz_PostManager.biz_post.GetSinglePost(new T_Post() { PostId = PostId });
            if (p != null)
            {
                //txtSimplifiedWord.Text = StringHelper.HtmlDecode(p.SimplifiedWord);
                //txtTraditionalWord.Text = p.TraditionalWord;
                //txtPinyin.Text = p.Pinyin;
                //txtWubi.Text = p.Wubi;
                //txtChangjei.Text = p.Changjei;
                //txtZhengma.Text = p.Zhengma;
                txtBushou.Text = p.Bushou;
                //txtTongjia.Text = p.Tongjia;
                //txtYiti.Text = p.Yiti;
                State.Checked = p.State==1;

                HidImageUrl.Value = p.ImageUrl;
                HidRadioList.Value = p.WordType;
                HidRadioWordDirection.Value = p.WordDirection.ToString();
                txtWord.Text = p.Word;
                HidWordId.Value = p.WordId.ToString();
                txtTWord.Text = p.TWord;
                HidTWord.Value = p.TWord;
                txtWriter.Text = p.WriterName;
                HidWriterId.Value = p.WriterId.ToString();
                txtFrom.Text = p.FromName;
                HidFromId.Value = p.FromId.ToString();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var p = new T_Post();

            if (Operate == OperateType.Update)
            {
                p =Biz_PostManager.biz_post.GetSinglePost(new T_Post(){PostId=PostId});
            }
            else
            {
                p.CreateDate = DateTime.Now;
            }

            //p.SimplifiedWord = txtSimplifiedWord.Text.Trim();
            //if (string.IsNullOrEmpty(p.SimplifiedWord))
            //{
            //    ShowError("请输入简体!");
            //    return;
            //}
            //p.TraditionalWord = txtTraditionalWord.Text.Trim();
            //p.Pinyin = txtPinyin.Text.Trim();
            //p.Wubi = txtWubi.Text.Trim();
            //p.Changjei = txtChangjei.Text.Trim();
            //p.Zhengma = txtZhengma.Text.Trim();
            p.State = State.Checked ? 1 : 0; ;
            //p.State = 0; 
            p.Bushou = txtBushou.Text.Trim();
            //p.Tongjia = txtTongjia.Text.Trim();
            //p.Yiti = txtYiti.Text.Trim();
            p.ImageUrl = HidImageUrl.Value;
            if (string.IsNullOrEmpty(p.ImageUrl))
            {
                ShowError("请选择作品!");
                return;
            }
            p.WordType =RequestHelper.FormString("RadioButtonList");
            p.WordTypeName = new admin_postlist().WordTypeTransForm(p.WordType);
            p.WordDirection = RadioWordDirection.SelectedValue;

            p.Word = txtWord.Text.Trim();
            p.WordId = StringHelper.StrToInt(HidWordId.Value, 0);
            p.TWord = txtTWord.Text.Trim();
            if (!string.IsNullOrEmpty(p.TWord))
            {
                if (p.WordId == 0)
                {
                    ShowError("请选择提示对应字形!");
                    return;
                }
                if (!Biz_WordManager.biz_word.ExistsWord(p.TWord))
                {
                    ShowError("请先录入对应字形!");
                    return;
                }
            }
            else
            {
                ShowError("请选择对应字形!");
                return;
            }
            if (string.IsNullOrEmpty(p.Word) || string.IsNullOrEmpty(p.WordId.ToString()))
            {
                ShowError("关联字体不能为空!");
                return;
            }
            p.WriterName = txtWriter.Text.Trim();
            p.WriterId = StringHelper.StrToInt(HidWriterId.Value, 0);
            if (!string.IsNullOrEmpty(p.WriterName))
            {
                if (p.WriterId == 0)
                {
                    ShowError("请选择提示作者!");
                    return;
                }
            }
            else
            {
                p.WriterId = 0;
            }

            p.FromName = txtFrom.Text.Trim();
            p.FromId = StringHelper.StrToInt(HidFromId.Value, 0);
            if (!string.IsNullOrEmpty(p.FromName))
            {
                if (p.FromId == 0)
                {
                    ShowError("请选择提示出处!");
                    return;
                }
            }
            else
            {
                p.FromId = 0;
            }
            p.UpdateDate = DateTime.Now;

            if (Operate == OperateType.Update)
            {
                Biz_PostManager.biz_post.UpdatePost(p);
                Response.Redirect("postedit.aspx?operate=update&postid=" + PostId + "&message=2");
                //Response.Redirect("postlist.aspx?result=2");
            }
            else
            {
                Biz_PostManager.biz_post.InsertPost(p);
                Response.Redirect("postlist.aspx?result=1");
            }
        }

        
    }
}