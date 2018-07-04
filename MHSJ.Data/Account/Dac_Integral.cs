namespace MHSJ.Data.Account
{
    using MHSJ.Data.Common;
    using MHSJ.Entity;
    using System;
    using System.Linq;

    public class Dac_Integral
    {
        public static Dac_Integral dac_integral = new Dac_Integral();
        public static readonly int Integral = 100;
        public static readonly int Number = 10;

        public bool AddIntegral(int id)
        {
            T_Integral entityObject = new T_Integral {
                CollectionnNumber = new int?(Number),
                Integral = new int?(Integral),
                AccountId = new int?(id)
            };
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_Integral>.Insert_IntoEntities(entities, entityObject, "T_Integral");
                }
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception.Message);
            }
            return false;
        }

        public T_Integral GetIntegral(int id)
        {
            T_Integral integral;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    integral = entities.T_Integral.SingleOrDefault<T_Integral>(c => c.AccountId == id);
                }
            }
            catch (Exception)
            {
                integral = null;
            }
            return integral;
        }
    }
}

