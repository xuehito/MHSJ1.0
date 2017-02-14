using System.IO;
using System.Web;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Core.Service.Admin;
using MHSJ.Entity;
using MHSJ.Entity.Common;

namespace MHSJ.Web
{
    /// <summary>
    ///     操作类型
    /// </summary>
    public enum OperateType
    {
        /// <summary>
        ///     添加
        /// </summary>
        Insert = 0,

        /// <summary>
        ///     更新
        /// </summary>
        Update = 1,

        /// <summary>
        ///     删除
        /// </summary>
        Delete = 2,
    }

    /// <summary>
    ///     后台基类
    /// </summary>
    public class AdminPage : PageBase
    {
        /// <summary>
        ///     操作
        /// </summary>
        private readonly string _operate = RequestHelper.QueryString("Operate");

        /// <summary>
        ///     输出信息
        /// </summary>
        protected string ResponseMessage = string.Empty;

        protected SettingInfo setting;

        public AdminPage()
        {
            CheckLoginAndPermission();
            setting = SettingManager.GetSetting();
        }

        /// <summary>
        ///     操作类型
        /// </summary>
        public OperateType Operate
        {
            get
            {
                switch (_operate)
                {
                    case "update":
                        return OperateType.Update;
                    case "delete":
                        return OperateType.Delete;
                    default:
                        return OperateType.Insert;
                }
            }
        }

        /// <summary>
        ///     操作字符串
        /// </summary>
        public string OperateString
        {
            get { return _operate; }
        }

        /// <summary>
        ///     检查登录和权限
        /// </summary>
        protected void CheckLoginAndPermission()
        {
            if (!PageUtils.IsLogin)
            {
                HttpContext.Current.Response.Redirect("login.aspx?returnurl=" +
                                                      HttpContext.Current.Server.UrlEncode(RequestHelper.CurrentUrl));
            }
            UserInfo user = UserManager.GetUser(PageUtils.CurrentUserId);

            if (user == null) //删除已登陆用户时有效
            {
                PageUtils.RemoveUserCookie();
                HttpContext.Current.Response.Redirect("login.aspx?returnurl=" +
                                                      HttpContext.Current.Server.UrlEncode(RequestHelper.CurrentUrl));
            }

            if (
                StringHelper.GetMD5(user.UserId + HttpContext.Current.Server.UrlEncode(user.UserName) + user.Password) !=
                PageUtils.CurrentKey)
            {
                PageUtils.RemoveUserCookie();
                HttpContext.Current.Response.Redirect("login.aspx?returnurl=" +
                                                      HttpContext.Current.Server.UrlEncode(RequestHelper.CurrentUrl));
            }

            if (PageUtils.CurrentUser.Status == 0)
            {
                ResponseError("您的用户名已停用", "您的用户名已停用,请与管理员联系!");
            }


            string[] plist =
            {
                "themelist.aspx", "themeedit.aspx", "linklist.aspx", "userlist.aspx", "setting.aspx",
                "categorylist.aspx", "taglist.aspx", "commentlist.aspx"
            };
            if (PageUtils.CurrentUser.Type == (int) UserType.Author)
            {
                string pageName = Path.GetFileName(HttpContext.Current.Request.Url.ToString()).ToLower();

                foreach (string p in plist)
                {
                    if (pageName == p)
                    {
                        ResponseError("没有权限", "您没有权限使用此功能,请与管理员联系!");
                    }
                }
            }
        }


        protected void SetPageTitle(string title)
        {
            Page.Title = title + " - 管理中心 - 梅花书检";
        }

        /// <summary>
        ///     错误提示
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string ShowError(string error)
        {
            ResponseMessage = "<div class=\"p_error\">";
            ResponseMessage += error;
            ResponseMessage += "</div>";
            return ResponseMessage;
        }

        /// <summary>
        ///     正确提示
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ShowMessage(string message)
        {
            ResponseMessage = "<div class=\"p_message\">";
            ResponseMessage += message;
            ResponseMessage += "</div>";
            return ResponseMessage;
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
            }
        }
    }
}