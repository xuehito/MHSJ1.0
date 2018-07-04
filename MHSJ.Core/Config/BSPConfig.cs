namespace MHSJ.Core.Config
{
    using MHSJ.Core.Config.Info;
    using System;

    public class BSPConfig
    {
        private static ShopConfigInfo _shopconfiginfo = null;

        public static ShopConfigInfo ShopConfig
        {
            get
            {
                return _shopconfiginfo;
            }
        }
    }
}

