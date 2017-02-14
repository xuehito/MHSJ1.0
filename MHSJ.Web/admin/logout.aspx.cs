using System;
using System.Web.UI;
using MHSJ.Web;

public partial class admin_logout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageUtils.RemoveUserCookie();
        Response.Redirect("../");
    }
}