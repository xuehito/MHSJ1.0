using System;
using System.Web.UI;
using MHSJ.Core.Common;

namespace MHSJ.Web.admin
{
    public partial class admin : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetCssName(string fileType)
        {
            string filename = StringHelper.GetFileName(Request.Url.ToString());

            if (filename.IndexOf(fileType) != -1)
            {
                return "current";
            }
            return string.Empty;
        }
    }
}