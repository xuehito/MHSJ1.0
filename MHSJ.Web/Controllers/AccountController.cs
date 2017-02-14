using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using MHSJ.Core.Service.Account;
using MHSJ.Data.Account;
using MHSJ.Entity;
using MHSJ.Web.Models.Account;

namespace MHSJ.Web.Controllers
{
    public class AccountController : BaseWebController
    {
        #region 登录
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, String returnUrl)
        {
            if (returnUrl.Length == 0)
                returnUrl = "/";

            if (string.IsNullOrEmpty(model.VerifyCode) || model.VerifyCode != PageUtils.VerifyCode)
            {
                ViewBag.ErrorMessage = "验证码错误!";
                return View(model);
            }

            T_AccountInfo account = Dac_Account.dac_account.GetSingleaAccount(model.Name.ToLower(),
                model.Password.ToLower());

            if (account != null)
            {
                if (account.Status == 0)
                {
                    ViewBag.ErrorMessage = "此用户已停用!";
                    return View(model);
                }
                int expires = 43200;
                PageUtils.WriteAccountCookie(account.AccountId, account.AccountName, account.Password, expires);
                return RedirectToLocal(returnUrl);
            }

            ViewBag.ErrorMessage = "用户名或密码错误!";

            return View(model);
        }
        #endregion


        #region 注册用户
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, String returnUrl)
        {
            if (returnUrl.Length == 0)
                returnUrl = "/";

            if (string.IsNullOrEmpty(model.VerifyCode) || model.VerifyCode != PageUtils.VerifyCode)
            {
                ViewBag.ErrorMessage = "验证码错误!";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    var accountInfo = new T_AccountInfo();
                    accountInfo.Name = model.Name.ToLower();
                    accountInfo.Password = model.Password;
                    accountInfo.AccountName = model.Name.ToLower();
                    accountInfo.Email = "";
                    accountInfo.Phone = "";
                    accountInfo.Status = 1;
                    accountInfo.Type = 1;
                    accountInfo.CreateDate = DateTime.Now;

                    if(!Biz_AccountManager.biz_account.ExistsName(accountInfo.Name))
                    {
                        Biz_AccountManager.biz_account.CreateUserAndAccount(accountInfo);
                        // return RedirectToAction("Index", "Home");
                        return PromptView("/Account/Login", "注册成功！");
                    }

                    ViewBag.ErrorMessage = "该用户名已存在!";

                    return Redirect(returnUrl);
                    
                }
                catch (MembershipCreateUserException e)
                {
                    
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        #endregion

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            PageUtils.RemoveAccountCookie();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Logout()
        {
            PageUtils.RemoveAccountCookie();

            return RedirectToAction("Index", "Home");
        }

        #region 帮助程序

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}