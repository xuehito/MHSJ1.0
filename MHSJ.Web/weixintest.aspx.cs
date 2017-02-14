using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace MHSJ.Web
{
    public partial class weixintest : Page
    {
        private const string Token = "xxddweixin"; //你的token

        protected void Page_Load(object sender, EventArgs e)

        {
            string postStr = "";

            if (Request.HttpMethod.ToLower() == "post")

            {
                Stream s = HttpContext.Current.Request.InputStream;

                var b = new byte[s.Length];

                s.Read(b, 0, (int) s.Length);

                postStr = Encoding.UTF8.GetString(b);

                if (!string.IsNullOrEmpty(postStr))

                {
                    //ResponseMsg(postStr);

                    Response.Write(ResponseMsg(postStr));

                    Response.End();
                }

                //WriteLog("postStr:" + postStr);
            }

            else

            {
                Valid();
            }
        }

        /// <summary>
        ///     验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()

        {
            string signature = Request.QueryString["signature"];

            string timestamp = Request.QueryString["timestamp"];

            string nonce = Request.QueryString["nonce"];

            string[] ArrTmp = {Token, timestamp, nonce};

            Array.Sort(ArrTmp); //字典排序

            string tmpStr = string.Join("", ArrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");

            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)

            {
                return true;
            }

            return false;
        }

        private void Valid()

        {
            string echoStr = Request.QueryString["echoStr"];

            if (CheckSignature())

            {
                if (!string.IsNullOrEmpty(echoStr))

                {
                    Response.Write(echoStr);

                    Response.End();
                }
            }
        }

        /// <summary>
        ///     返回信息结果(微信信息返回)
        /// </summary>
        /// <param name="weixinXML"></param>
        private string ResponseMsg(string weixinXML)

        {
            return weixinXML;
        }

        /// <summary>
        ///     unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private DateTime UnixTimeToTime(string timeStamp)

        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            long lTime = long.Parse(timeStamp + "0000000");

            var toNow = new TimeSpan(lTime);

            return dtStart.Add(toNow);
        }

        /// <summary>
        ///     datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(DateTime time)

        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            return (int) (time - startTime).TotalSeconds;
        }

        /// <summary>
        ///     写日志(用于跟踪)
        /// </summary>
        private void WriteLog(string strMemo)

        {
            string filename = Server.MapPath("/logs/log.txt");

            if (!Directory.Exists(Server.MapPath("//logs//")))

                Directory.CreateDirectory("//logs//");

            StreamWriter sr = null;

            try

            {
                if (!File.Exists(filename))

                {
                    sr = File.CreateText(filename);
                }

                else

                {
                    sr = File.AppendText(filename);
                }

                sr.WriteLine(strMemo);
            }

            catch

            {
            }

            finally

            {
                if (sr != null)

                    sr.Close();
            }
        }
    }
}