using System;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class admin_login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageUtils.IsLogin)
            {
                Response.Redirect("default.aspx");
            }
            Title = "登录 - 管理中心 - 梅花书检";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = StringHelper.HtmlEncode(txtUserName.Text.Trim());
            //string password = StringHelper.GetMD5(txtPassword.Text.Trim());
            string password = txtPassword.Text.Trim();
            int expires = chkRemember.Checked ? 43200 : 0;
            string verifyCode = txtVerifyCode.Text;

            if (string.IsNullOrEmpty(verifyCode) || verifyCode != PageUtils.VerifyCode)
            {
                lblMessage.Text = "验证码错误!";
                return;
            }

            UserInfo user = UserManager.GetUser(userName, password);

            if (user != null)
            {
                if (user.Status == 0)
                {
                    lblMessage.Text = "此用户已停用!";
                    return;
                }
                PageUtils.WriteUserCookie(user.UserId, user.UserName, user.Password, expires);
                Response.Redirect("default.aspx");
            }
            else
            {
                lblMessage.Text = "用户名或密码错误!";
            }
        }
    }

}