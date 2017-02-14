namespace MHSJ.Web.Models
{
    /// <summary>
    ///     提示模型类
    /// </summary>
    public class PromptModel
    {
        private string _backurl = ""; //返回地址
        private int _countdowntime = 3; //倒计时时间
        private bool _isautoback = true; //是否自动返回
        private bool _isshowbacklink = true; //是否显示返回地址
        private string _message = ""; //提示信息

        public PromptModel(string message)
        {
            CountdownModel = 0;
            _message = message;
            _isshowbacklink = false;
            _isautoback = false;
        }

        public PromptModel(string backUrl, string message)
        {
            CountdownModel = 0;
            _backurl = backUrl;
            _message = message;
        }

        /// <summary>
        ///     返回地址
        /// </summary>
        public string BackUrl
        {
            get { return _backurl; }
            set { _backurl = value; }
        }

        /// <summary>
        ///     提示信息
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        ///     倒计时模型
        /// </summary>
        public int CountdownModel { get; set; }

        /// <summary>
        ///     倒计时时间
        /// </summary>
        public int CountdownTime
        {
            get { return _countdowntime; }
            set { _countdowntime = value; }
        }

        /// <summary>
        ///     是否显示返回地址
        /// </summary>
        public bool IsShowBackLink
        {
            get { return _isshowbacklink; }
            set { _isshowbacklink = value; }
        }

        /// <summary>
        ///     是否自动返回
        /// </summary>
        public bool IsAutoBack
        {
            get { return _isautoback; }
            set { _isautoback = value; }
        }
    }
}