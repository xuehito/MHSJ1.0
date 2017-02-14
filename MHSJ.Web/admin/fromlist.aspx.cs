using System;
using System.Collections.Generic;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class admin_fromlist : AdminPage
    {
        /// <summary>
        ///     Id
        /// </summary>
        protected int FromId = RequestHelper.QueryInt("FromId");

        /// <summary>
        ///     修改时提示
        /// </summary>
        protected string PasswordMessage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("出处管理");

            if (!IsPostBack)
            {
                BindFromList();

                if (Operate == OperateType.Update)
                {
                    BindFrom();
                    btnEdit.Text = "修改";
                    //txtFromName.Enabled = false;

                    PasswordMessage = "(不修改请留空)";
                }
                else if (Operate == OperateType.Delete)
                {
                    DeleteUser();
                }
            }


            ShowResult();
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
                    break;
            }
        }

        /// <summary>
        ///     绑定实体
        /// </summary>
        protected void BindFrom()
        {
            T_From From = FromManager.GetFrom(FromId);
            if (From != null)
            {
                txtFromName.Text = StringHelper.HtmlDecode(From.FromName);
                txtFromAliases.Text = StringHelper.HtmlDecode(From.FromAliases);

                txtDescription.Text = StringHelper.HtmlDecode(From.Description);

                txtDisplayOrder.Text = From.DisplayOrder.ToString();
            }
        }

        /// <summary>
        ///     绑定列表
        /// </summary>
        protected void BindFromList()
        {
            List<T_From> list = FromManager.GetFromList();
            rptUser.DataSource = list;
            rptUser.DataBind();
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        protected void DeleteUser()
        {
            FromManager.DeleteFrom(FromId);
            Response.Redirect("Fromlist.aspx?result=3");
        }

        /// <summary>
        ///     编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var from = new T_From();
            if (Operate == OperateType.Update)
            {
                from = FromManager.GetFrom(FromId);
            }
            else
            {
                from.CreateDate = DateTime.Now;
            }
            from.FromName = StringHelper.HtmlEncode(txtFromName.Text.Trim());
            from.FromAliases = StringHelper.HtmlEncode(txtFromAliases.Text.Trim());
            from.Description = StringHelper.HtmlEncode(txtDescription.Text.Trim());
            from.DisplayOrder = StringHelper.StrToInt(txtDisplayOrder.Text, 1000);

            if (string.IsNullOrEmpty(txtFromName.Text.Trim()))
            {
                ShowError("请输入出处名称!");
                return;
            }
            //if (FromManager.ExistsFromName(From.FromName))
            //{
            //    ShowError("该作家已存在,请换之");
            //    return;
            //}
            if (Operate == OperateType.Update)
            {
                FromManager.UpdateFrom(from);
                Response.Redirect("Fromlist.aspx?result=2");
            }
            else
            {
                from.FromId = FromManager.InsertFrom(from);
                Response.Redirect("Fromlist.aspx?result=1");
            }
        }
    }
}