using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MHSJ.Core.Common;

namespace MHSJ.Web
{
    public partial class shouxie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NetHelper.ChineseStringConverter.TraditionalToSimplified("这是一个汉字转换测试");

            NetHelper.ChineseStringConverter.SimplifiedToTraditional("这是一个汉字转换测试");

            NetHelper.GetPinyin("这是一个汉字转换测试");

            NetHelper.GetFirstPinyin("这是一个汉字转换测试");
        }
    }
}