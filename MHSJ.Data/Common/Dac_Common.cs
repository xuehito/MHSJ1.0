using System.Configuration;
using MHSJ.Entity;

namespace MHSJ.Data.Common
{
    public class Dac_Common
    {
        public static Dac_Common dac_Common = new Dac_Common();

        #region 返回模型实体

        /// <summary>
        ///     返回模型实体
        /// </summary>
        /// <returns></returns>
        public MHSJEntities MHSJEntities()
        {
            var entities = new MHSJEntities(conStr());
            return entities;
        }

        #endregion

        #region 返回数据库模型连接字符串

        /// <summary>
        ///     返回数据库模型连接字符串
        /// </summary>
        /// <returns></returns>
        public string conStr()
        {
            string conStr = ConfigurationManager.ConnectionStrings["MHSJEntities"].ConnectionString;
            return conStr;
        }

        #endregion
    }
}