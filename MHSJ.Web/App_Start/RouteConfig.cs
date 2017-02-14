using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace MHSJ.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //避免aspx页面的请求传递给控制器
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");

            routes.MapRoute(
               "Post", // 路由名称
               "post/n/{id}/", // 带有参数的 URL
               new { controller = "Post", action = "PostId", id = UrlParameter.Optional } // 参数默认值
           );

            routes.MapRoute(
               "Search", // 路由名称
               "search/kw/{keyword}/", // 带有参数的 URL
               new { controller = "Search", action = "SearchWord", keyword = UrlParameter.Optional },
               new {}// 参数默认值
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}