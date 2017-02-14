using MHSJ.Web.Controllers;
using MHSJ.Web.Models;

namespace MHSJ.Web.ViewPages
{
    /// <summary>
    ///     前台视图页面基类型
    /// </summary>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public WebWorkContext WorkContext;

        public override void InitHelpers()
        {
            base.InitHelpers();
            WorkContext = ((BaseWebController) (ViewContext.Controller)).WorkContext;
        }
    }

    /// <summary>
    ///     前台视图页面基类型
    /// </summary>
    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}