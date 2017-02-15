using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Account
{
    public class Dac_Account
    {
        public static Dac_Account dac_account =new Dac_Account();

        public T_AccountInfo GetSingleaAccount(string name, string pw)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    return entities.T_AccountInfo.SingleOrDefault(c => c.Name == name && c.Password==pw);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public bool ExistsName(string name)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var info=entities.T_AccountInfo.SingleOrDefault(c => c.Name == name);
                    if (info== null)
                    {
                        return true;
                    }
                }
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        public V_Account GetAccountInfo(int userId)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    return entities.V_Account.SingleOrDefault(c => c.AccountId == userId);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public void CreateUserAndAccount(T_AccountInfo model)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    //todo 保存
                     //entities.T_AccountInfo.u(c => c.Name == name);
                }
            }
            catch (Exception exception)
            {
                return ;
            }
        }

        public void UpdateAccount(T_AccountInfo model)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    //todo 修改
                    //entities.T_AccountInfo.u(c => c.Name == name);
                }
            }
            catch (Exception exception)
            {
                return;
            }
        }

    }
}
