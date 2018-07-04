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

        public bool CreateUserAndAccount(T_AccountInfo accountInfo)
        {
            return (Dac_Account.dac_account.CreateUserAndAccount(accountInfo) && Dac_Integral.dac_integral.AddIntegral(accountInfo.AccountId));
        }

        public bool ExistsAccountId(int id)
        {
            return Dac_Account.dac_account.ExistsAccountId(id);
        }

        public bool ExistsName(string name)
        {
            return true;
        }

        public V_Account GetAccountInfo(int id)
        {
            return Dac_Account.dac_account.GetAccountInfo(id);
        }

        public List<T_AccountInfo> GetListAccount(T_AccountInfo item, int pageSize, int pageIndex, out int recordCount)
        {
            return Dac_Account.dac_account.GetListAccount(item, pageSize, pageIndex, out recordCount);
        }

        public T_AccountInfo GetSingleaAccount(int id)
        {
            return Dac_Account.dac_account.GetSingleaAccount(id);
        }

        public T_AccountInfo GetSingleaAccount(string name, string password)
        {
            return Dac_Account.dac_account.GetSingleaAccount(name, password);
        }

        public bool UpdateAccount(T_AccountInfo accountInfo)
        {
            return Dac_Account.dac_account.UpdateAccount(accountInfo);
        }
    }
}
