using System;
using System.Collections.Generic;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class admin_writer : AdminPage
    {
        /// <summary>
        ///     Id
        /// </summary>
        protected int Id = RequestHelper.QueryInt("Id");

        /// <summary>
        ///     修改时提示
        /// </summary>
        protected string PasswordMessage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("作家管理");

            if (!IsPostBack)
            {
                BindWriterList();

                if (Operate == OperateType.Update)
                {
                    BindWriter();
                    btnEdit.Text = "修改";
                    txtWriterName.Enabled = false;

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
            T_Writer writer = WriterManager.GetWriter(Id);
            if (writer != null)
            {
                txtWriterName.Text = StringHelper.HtmlDecode(writer.WriterName);
                txtWriterAliases.Text = StringHelper.HtmlDecode(writer.WriterAliases);

                txtDynasty.Text = StringHelper.HtmlDecode(writer.Dynasty);
                txtDescription.Text = StringHelper.HtmlDecode(writer.Description);

                chkStatus.Checked = writer.Status == 1 ? true : false;
                txtDisplayOrder.Text = writer.DisplayOrder.ToString();
            }
        }

        /// <summary>
        ///     绑定列表
        /// </summary>
        protected void BindWriterList()
        {
            List<T_Writer> list = WriterManager.GetWriterList();
            rptUser.DataSource = list;
            rptUser.DataBind();
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        protected void DeleteUser()
        {
            if (Id == PageUtils.CurrentUserId)
            {
                Response.Redirect("writerlist.aspx?result=4");
            }
            WriterManager.DeleteWriter(Id);
            Response.Redirect("writerlist.aspx?result=3");
        }

        /// <summary>
        ///     编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var writer = new T_Writer();
            if (Operate == OperateType.Update)
            {
                writer = WriterManager.GetWriter(Id);
            }
            else
            {
                writer.CreateDate = DateTime.Now;
            }
            writer.WriterName = StringHelper.HtmlEncode(txtWriterName.Text.Trim());
            writer.WriterAliases = StringHelper.HtmlEncode(txtWriterAliases.Text.Trim());
            writer.Dynasty = StringHelper.HtmlEncode(txtDynasty.Text.Trim());
            writer.Description = StringHelper.HtmlEncode(txtDescription.Text.Trim());
            writer.DisplayOrder = StringHelper.StrToInt(txtDisplayOrder.Text, 1000);
            writer.Status = chkStatus.Checked ? 1 : 0;

            if (string.IsNullOrEmpty(txtWriterName.Text.Trim()))
            {
                ShowError("请输入作家名!");
                return;
            }
            //if (WriterManager.ExistsWriterName(writer.WriterName))
            //{
            //    ShowError("该作家已存在,请换之");
            //    return;
            //}


            if (Operate == OperateType.Update)
            {
                WriterManager.UpdateWriter(writer);
                Response.Redirect("writerlist.aspx?result=2");
            }
            else
            {
                writer.Id = WriterManager.InsertWriter(writer);
                Response.Redirect("writerlist.aspx?result=1");
            }
        }
    }
}