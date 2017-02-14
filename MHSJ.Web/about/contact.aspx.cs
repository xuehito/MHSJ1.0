using System;
using MHSJ.Core.Service.Account;

namespace MHSJ.Web.about
{
    public partial class contact : Pager
    {
        public int Integral { get; set; }//积分

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageUtils.IsAccountLogin)
            {
                var info = Biz_AccountManager.biz_account.GetAccountInfo(PageUtils.CurrentAccountId);
                if (info != null)
                {
                    Integral = Convert.ToInt32(info.Integral);
                }
            }
        }
    }
}