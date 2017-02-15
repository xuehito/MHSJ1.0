using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Data.Account;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Account
{
    public class Biz_LinkManager
    {
        public static Biz_LinkManager biz_link = new Biz_LinkManager();

        public bool ExistsName(string name)
        {
            return true;
        }

        public void CreateUserAndAccount(T_AccountInfo model)
        {
            Dac_Account.dac_account.CreateUserAndAccount(model);
        }
    }
}
