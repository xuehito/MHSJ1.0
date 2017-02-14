using System;

namespace MHSJ.Entity
{
    /// <summary>
    ///     用户实体
    /// </summary>
    public class UserInfo : IComparable<UserInfo>
    {
        private DateTime _createdate;

        #region 非字段

        private string _link;
        private string _url;

        /// <summary>
        ///     地址
        /// </summary>
        //public string Url
        //{
        //    get
        //    {
        //        string url = string.Empty;

        //        if (Utils.IsSupportUrlRewriter == false)
        //        {
        //            url = string.Format("{0}default.aspx?type=author&username={1}", ConfigHelper.SiteUrl,
        //                StringHelper.UrlEncode(UserName));
        //        }
        //        else
        //        {
        //            return ConfigHelper.SiteUrl + "author/" + StringHelper.UrlEncode(UserName) +
        //                   SettingManager.GetSetting().RewriteExtension;
        //        }
        //        return Utils.CheckPreviewThemeUrl(url);
        //    }
        //}

        /// <summary>
        ///     连接
        /// </summary>
        //public string Link
        //{
        //    //set { _link = value; }
        //    //get { return _link; }
        //    get { return string.Format("<a href=\"{0}\" title=\"作者:{1}\">{1}</a>", Url, Name); }
        //}

        #endregion

        /// <summary>
        ///     用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     用户类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     个人网站
        /// </summary>
        public string SiteUrl { get; set; }


        /// <summary>
        ///     头像地址
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     用户状态
        ///     1:使用,0:停用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     统计日志数
        /// </summary>
        public int PostCount { get; set; }

        /// <summary>
        ///     评论数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        ///     排序
        /// </summary>
        public int Displayorder { get; set; }

        /// <summary>
        ///     创建日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        public int CompareTo(UserInfo other)
        {
            if (Displayorder != other.Displayorder)
            {
                return Displayorder.CompareTo(other.Displayorder);
            }
            return UserId.CompareTo(other.UserId);
        }
    }
}