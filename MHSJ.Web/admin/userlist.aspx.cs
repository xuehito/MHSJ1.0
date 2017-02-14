using System;
using System.Collections.Generic;
using MHSJ.Core.Service.Account;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class userlist : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("文字管理");

            if (!IsPostBack)
            {
                BindUserList();
            }
        }

        /// <summary>
        ///     绑定列表
        /// </summary>
        protected void BindUserList()
        {
            var itemQuery = new T_AccountInfo();

            int totalRecord = 0;
            Pager1.PageSize = 22;

            List<T_AccountInfo> list = Biz_AccountManager.biz_account.GetListAccount(itemQuery, Pager1.PageSize,
                Pager1.PageIndex, out totalRecord);
            rptUserList.DataSource = list;
            rptUserList.DataBind();
            Pager1.RecordCount = totalRecord;
        }
    }
}