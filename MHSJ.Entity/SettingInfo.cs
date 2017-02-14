namespace MHSJ.Entity
{
    /// <summary>
    ///     配置实体
    ///     邮件设置,发邮件设置
    /// </summary>
    public class SettingInfo
    {
        private int _enableverifycode = 1;


        private string _sitedescription = "";
        private string _sitename = "梅花书检";
        private int _sitestatus = 1;
        private int _sitetotaltype = 1;


        #region 全局

        /// <summary>
        ///     网站名称
        /// </summary>
        public string SiteName
        {
            set { _sitename = value; }
            get { return _sitename; }
        }

        /// <summary>
        ///     网站描述
        /// </summary>
        public string SiteDescription
        {
            set { _sitedescription = value; }
            get { return _sitedescription; }
        }


        /// <summary>
        ///     Meta 关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        ///     Meta 描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///     网站状态
        /// </summary>
        public int SiteStatus
        {
            set { _sitestatus = value; }
            get { return _sitestatus; }
        }

        /// <summary>
        ///     版本
        /// </summary>
        public string Version
        {
            get { return "1.3"; }
        }

        //  public const string AssemblyVersion = "0.5.0";
        /// <summary>
        ///     程序集版本
        /// </summary>
        /// <summary>
        ///     统计类型(包括文章浏览次数,网站访问次数)
        ///     1:按刷新次数统计,2:按IP 24小时统计一次
        /// </summary>
        public int SiteTotalType
        {
            set { _sitetotaltype = value; }
            get { return _sitetotaltype; }
        }

        /// <summary>
        ///     启用验证码
        /// </summary>
        public int EnableVerifyCode
        {
            set { _enableverifycode = value; }
            get { return _enableverifycode; }
        }

        #endregion

        #region 页脚

        /// <summary>
        ///     页脚Html
        /// </summary>
        public string FooterHtml { get; set; }

        #endregion
    }
}