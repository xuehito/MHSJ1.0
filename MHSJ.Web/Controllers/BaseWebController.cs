using System.Web.Mvc;
using MHSJ.Core.Common;
using MHSJ.Core.Config;
using MHSJ.Core.Config.Info;
using MHSJ.Core.Service.Account;
using MHSJ.Web.Models;
using MHSJ.Web.Models.Account;

namespace MHSJ.Web.Controllers
{
    public class BaseWebController : Controller
    {
        public WebWorkContext WorkContext = new WebWorkContext();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            
            WorkContext.IP = WebHelper.GetIP();
            //WorkContext.Region = Regions.GetRegionByIP(WorkContext.IP);
            WorkContext.Url = WebHelper.GetUrl();
            WorkContext.UrlReferrer = WebHelper.GetUrlReferrer();

            GetIntegral();//查询积分

            Load();
        }

        public void Load()
        {
            ViewBag.SiteTitle = ShopConfigInfo.ShopConfig.SiteTitle;
            ViewBag.SiteUrl = ShopConfigInfo.ShopConfig.SiteUrl;
            ViewBag.ShopName = ShopConfigInfo.ShopConfig.ShopName;
            ViewBag.SEO = "书法字典," + ViewBag.SiteTitle;
            ViewBag.Url = WorkContext.Url;
        }

       

        /// <summary>
        ///     提示信息视图
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string message)
        {
            return View("Prompt", new PromptModel(message));
        }

        /// <summary>
        ///     提示信息视图
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string backUrl, string message)
        {
            return View("Prompt", new PromptModel(backUrl, message));
        }

        public void GetIntegral()
        {
            if (PageUtils.IsAccountLogin)
            {
                var item = Biz_AccountManager.biz_account.GetAccountInfo(PageUtils.CurrentAccountId);
                
                ViewBag.Integral = item.Integral;
            }
        }
    }
}