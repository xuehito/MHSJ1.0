using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Data.Account;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Account
{
    public class Biz_AccountManager
    {
        public static Biz_AccountManager biz_account =new Biz_AccountManager();

        public bool ExistsName(string name)
        {
            return true;
        }

        public void CreateUserAndAccount(T_AccountInfo model)
        {
            Dac_Account.dac_account.CreateUserAndAccount(model);
        }

        public V_Account GetAccountInfo(int userId)
        {
            return Dac_Account.dac_account.GetAccountInfo(userId);
        }

        public void UpdateAccount(T_AccountInfo model)
        {
            Dac_Account.dac_account.UpdateAccount(model);
        }
    }
}
