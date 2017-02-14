using System;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace MHSJ.Core.Common
{
    /// <summary>
    ///     网络工具类
    /// </summary>
    /// <remarks>
    ///     date:2012.7.5
    /// </remarks>
    public class NetHelper
    {
        /// <summary>
        ///     获取某地址的状态码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpStatusCode GetHttpStatusCode(string url)
        {
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    return response.StatusCode;
                }
            }

            catch
            {
                return HttpStatusCode.ServiceUnavailable;
            }
        }

        #region 汉字转换
        /// <summary>
        /// 汉字转换
        /// </summary>
        public static class ChineseStringConverter
        {
            internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
            internal const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
            internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;
            [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);

            /// <summary>
            /// 繁转简
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static string TraditionalToSimplified(string source)
            {
                String target = new String(' ', source.Length);
                int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_SIMPLIFIED_CHINESE, source, source.Length, target, source.Length);

                return target;
            }
            /// <summary>
            /// 简转繁
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static string SimplifiedToTraditional(string source)
            {
                String target = new String(' ', source.Length);
                int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_TRADITIONAL_CHINESE, source, source.Length, target, source.Length);
                return target;
            }
        }
        #endregion

        /// <summary> 
        /// 简体转换为繁体
        /// </summary> 
        /// <param name="str">简体字</param> 
        /// <returns>繁体字</returns> 
        public static string GetTraditional(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.SimplifiedToTraditional);
            return r;
        }
        /// <summary> 
        /// 繁体转换为简体
        /// </summary> 
        /// <param name="str">繁体字</param> 
        /// <returns>简体字</returns> 
        public static string GetSimplified(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);
            return r;
        }

        /// <summary> 
        /// 汉字转化为拼音
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>全拼</returns> 
        public static string GetPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r.ToLower();//转化为小写
        }

        /// <summary> 
        /// 汉字转化为拼音首字母
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>首字母</returns> 
        public static string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }
    }
}