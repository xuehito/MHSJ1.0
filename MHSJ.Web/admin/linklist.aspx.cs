using System;
using System.Collections.Generic;
using MHSJ.Core.Common;
using MHSJ.Core.Service.Link;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class linklist : AdminPage
    {
        /// <summary>
        ///     Id
        /// </summary>
        protected int Id = RequestHelper.QueryInt("Id");

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("作家管理");

            if (!IsPostBack)
            {
                BindLinkList();

                txtTypeName.Text = "外链";
                txtTypeName.Enabled = false;

                if (Operate == OperateType.Update)
                {
                    BindLink();
                    btnEdit.Text = "修改";
                }
                else if (Operate == OperateType.Delete)
                {
                    DeleteLink();
                }
            }

            ShowResult();
        }

        /// <summary>
        ///     绑定实体
        /// </summary>
        protected void BindLink()
        {
            T_Links links = Biz_LinkManager.biz_link.GetSingleLink(Id);
            if (links != null)
            {
                txtName.Text = StringHelper.HtmlDecode(links.Name);
                txtUrl.Text = StringHelper.HtmlDecode(links.Url);
                txtTypeName.Text = StringHelper.HtmlDecode(links.TypeName);
                txtDisplayOrder.Text = links.DisplayOrder.ToString();
            }
        }


        /// <summary>
        ///     绑定列表
        /// </summary>
        protected void BindLinkList()
        {
            var itemQuery = new T_Links();
            Pager1.PageSize = 22;
            int totalRecord = 0;

            List<T_Links> list = Biz_LinkManager.biz_link.QueryList(itemQuery, Pager1.PageSize, Pager1.PageIndex,
                out totalRecord);
            rptLinks.DataSource = list;
            rptLinks.DataBind();
            Pager1.RecordCount = totalRecord;
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        protected void DeleteLink()
        {
            Biz_LinkManager.biz_link.DeleteLink(Id);
            Response.Redirect("linklist.aspx?result=3");
        }

        /// <summary>
        ///     编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var link = new T_Links();
            if (Operate == OperateType.Update)
            {
                link = Biz_LinkManager.biz_link.GetSingleLink(Id);
            }
            else
            {
                link.CreateDate = DateTime.Now;
            }
            link.Name = StringHelper.HtmlEncode(txtName.Text.Trim());
            link.Url = StringHelper.HtmlEncode(txtUrl.Text.Trim());
            link.Type = 1;
            link.TypeName = "外链";
            link.DisplayOrder = StringHelper.StrToInt(txtDisplayOrder.Text, 1000);
            link.UpdateDate = DateTime.Now;

            if (Operate == OperateType.Update)
            {
                Biz_LinkManager.biz_link.UpdateLink(link);
                Response.Redirect("linklist.aspx?result=2");
            }
            else
            {
                Biz_LinkManager.biz_link.InsertLink(link);
                Response.Redirect("linklist.aspx?result=1");
            }
        }
    }
}