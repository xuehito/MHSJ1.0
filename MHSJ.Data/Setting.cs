using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data
{
    public class Setting
    {
        public bool UpdateSetting(SettingInfo setting)
        {
            string cmdText = @"update [T_Sites] set [Setting]=@Setting";
            SqlParameter[] prams = {
                                        new SqlParameter("@Setting",SqlDbType.NVarChar)
                                     };
            prams[0].Value = Serialize(setting);

            return DbHelperSQL.ExecuteSql(cmdText, prams)==1;
        }

        public SettingInfo GetSetting()
        {
            string cmdText = "select top 1 [setting] from [T_Sites]";

            string str = Convert.ToString(DbHelperSQL.GetSingle(cmdText));

            object obj = DeSerialize(typeof (SettingInfo), str);
            if (obj == null)
            {
                return new SettingInfo();
            }

            return (SettingInfo) obj;
        }


        /// <summary>
        ///     xml序列化成字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>xml字符串</returns>
        public static string Serialize(object obj)
        {
            string returnStr = "";

            var serializer = new XmlSerializer(obj.GetType());


            var ms = new MemoryStream();
            XmlTextWriter xtw = null;
            StreamReader sr = null;
            try
            {
                xtw = new XmlTextWriter(ms, Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;
                serializer.Serialize(xtw, obj);
                ms.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(ms);
                returnStr = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
                if (sr != null)
                    sr.Close();
                ms.Close();
            }
            
            return returnStr;
        }

        /// <summary>
        ///     反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object DeSerialize(Type type, string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s);
            try
            {
                var serializer = new XmlSerializer(type);

                return serializer.Deserialize(new MemoryStream(b));
            }
            catch
            {
                //  throw ex;
                return null;
            }
        }
    }
}