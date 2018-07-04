using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Account
{
    public class Dac_Account
    {
        public static Dac_Account dac_account =new Dac_Account();

        public bool CreateUserAndAccount(T_AccountInfo accountInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_AccountInfo>.Insert_IntoEntities(entities, accountInfo, "T_AccountInfo");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistsAccountId(int id)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    if ((from c in entities.T_AccountInfo
                         where (c.AccountId == id) && (c.Status == 1)
                         select c).Count<T_AccountInfo>() <= 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }

        public bool ExistsName(string name)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    if ((from c in entities.T_AccountInfo
                         where c.Name == name
                         select c).Count<T_AccountInfo>() <= 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }

        public V_Account GetAccountInfo(int id)
        {
            V_Account account;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    account = entities.V_Account.SingleOrDefault<V_Account>(c => c.AccountId == id);
                }
            }
            catch (Exception)
            {
                account = null;
            }
            return account;
        }

        public List<T_AccountInfo> GetListAccount(T_AccountInfo item, int pageSize, int pageIndex, out int recordCount)
        {
            List<T_AccountInfo> list;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_AccountInfo> source = entities.T_AccountInfo;
                    recordCount = source.ToList<T_AccountInfo>().Count<T_AccountInfo>();
                    list = (from c in source
                            orderby c.CreateDate descending
                            select c).Skip<T_AccountInfo>((pageSize * (pageIndex - 1))).Take<T_AccountInfo>(pageSize).ToList<T_AccountInfo>();
                }
            }
            catch (Exception)
            {
                recordCount = 0;
                list = null;
            }
            return list;
        }

        public T_AccountInfo GetSingleaAccount(int id)
        {
            T_AccountInfo info;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    info = entities.T_AccountInfo.SingleOrDefault<T_AccountInfo>(c => c.AccountId == id);
                }
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }

        public T_AccountInfo GetSingleaAccount(string name, string passWrod)
        {
            T_AccountInfo info;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    info = entities.T_AccountInfo.SingleOrDefault<T_AccountInfo>(c => (c.Name == name) && (c.Password == passWrod));
                }
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }

        public bool UpdateAccount(T_AccountInfo accountInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    EntityKey key = new EntityKey("MHSJEntities.T_AccountInfo", "AccountId", accountInfo.AccountId);
                    Dac_EntityHelper<MHSJEntities, T_AccountInfo>.UpdateEntity(entities, accountInfo, key, false);
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
