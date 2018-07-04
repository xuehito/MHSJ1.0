namespace MHSJ.Core.Service.Account
{
    using MHSJ.Data.Account;
    using MHSJ.Entity;
    using System;

    public class Biz_IntegralManager
    {
        public static Biz_IntegralManager biz_integral = new Biz_IntegralManager();

        public T_Integral GetIntegral(int id)
        {
            return Dac_Integral.dac_integral.GetIntegral(id);
        }
    }
}

