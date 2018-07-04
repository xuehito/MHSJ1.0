namespace MHSJ.Data.Common
{
    using log4net;
    using log4net.Config;
    using System;

    public static class LogHelper
    {
        public static void Error(object msg)
        {
            ILog logger = LogManager.GetLogger("MHSJ");
            XmlConfigurator.Configure();
            logger.Error(msg);
        }

        public static void Warn(object msg)
        {
            ILog logger = LogManager.GetLogger("MHSJ");
            XmlConfigurator.Configure();
            logger.Warn(msg);
        }
    }
}

