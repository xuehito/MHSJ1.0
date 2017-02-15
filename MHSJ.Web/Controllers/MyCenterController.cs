using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MHSJ.Core.Service.Account;
using MHSJ.Core.Service.MyCenter;
using MHSJ.Entity;
using MHSJ.Web.Models.Account;

namespace MHSJ.Web.Controllers
{
    public class MyCenterController : BaseWebController
    {
        /// <summary>
        /// 查看我的收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult Collections()
        {
            if (!PageUtils.IsAccountLogin)
            {
                return RedirectToAction("Login", "Account", new RouteValueDictionary { { "returnUrl",  Request.Url.AbsolutePath } });
            }
            //var info = new T_Collection();
            //info.AccountId = PageUtils.CurrentAccountId;
            //int recordCount;

            //var list = Biz_CollectionManager.biz_collection.QueryCollectionPost(info, 20, 1, out recordCount);
            //if (list == null) return View();
            
            //var listModel = new List<V_Post>();
            //foreach (var li in list)
            //{
            //    var model = new V_Post();
            //    model.ImageUrl = ViewBag.SiteUrl + li.ImageUrl;
            //    model.FromName = li.FromName;
            //    model.WriterName = li.WriterName;
            //    model.PostId = li.PostId;
            //    //model.Tword = string.IsNullOrEmpty(li.Tword) ? li.SimplifiedWord : li.Tword;
            //    model.Tword = li.Tword;
            //    model.Browses = li.Browses;
            //    model.UpdateDate = li.clUpdateDate;

            //    listModel.Add(model);
            //}
            //return View(listModel);
            return View();
        }

        /// <summary>
        /// 我的积分
        /// </summary>
        /// <returns></returns>
        public ActionResult Integral()
        {
            if (PageUtils.IsAccountLogin)
            {
                var item = Biz_AccountManager.biz_account.GetAccountInfo(PageUtils.CurrentAccountId);
                var model = new AccountModel()
                {
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Integral = (item.Integral ?? 0),//积分
                    CollectionnNumber = (item.CollectionnNumber ?? 0),//收藏数
                };

                return View(model);
            }
            return PromptView("/Account/Login", "请先登录！");
        }

        /// <summary>
        /// 用户中心
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (PageUtils.IsAccountLogin)
            {
                var item = Biz_AccountManager.biz_account.GetAccountInfo(PageUtils.CurrentAccountId);
                var model = new AccountModel()
                {
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Phone = item.Phone,
                    Email = item.Email,
                    Integral = (item.Integral ?? 0),//积分
                    CollectionnNumber = (item.CollectionnNumber ?? 0),//收藏数
                };

                return View(model);
            }
            return PromptView("/Account/Login", "请先登录！");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInfo(AccountModel model, String returnUrl)
        {
            if (PageUtils.IsAccountLogin)
            {
                try
                {
                    var accountInfo = new T_AccountInfo();
                    accountInfo.Email = model.Email;
                    accountInfo.Phone = model.Phone;
                    accountInfo.Status = 1;
                    accountInfo.Type = 1;
                    accountInfo.AccountId = model.AccountId;
                    accountInfo.UpdateDate = DateTime.Now;

                    //if (Biz_AccountManager.biz_account.ExistsAccountId(accountInfo.AccountId))
                    //{
                        Biz_AccountManager.biz_account.UpdateAccount(accountInfo);
                        return PromptView("/", "修改成功！");
                    //}

                    //ViewBag.ErrorMessage = "修改失败，帐号或不存在!";

                    //return View("Index",model);

                }
                catch (MembershipCreateUserException e)
                {
                    
                }
            }
            return PromptView("/Account/Login", "请先登录！");
        }
    }
}