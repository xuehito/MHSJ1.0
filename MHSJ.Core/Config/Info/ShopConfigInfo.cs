namespace MHSJ.Core.Config.Info
{
    using System;

    [Serializable]
    public class ShopConfigInfo
    {
        private string _icp = "冀ICP22222";
        private int _islicensed = 1;
        private string _script = "";
        private string _seodescription = "";
        private string _seokeyword = "";
        private string _shopname = "梅花书检";
        private string _sitetitle = "梅花书检";
        private string _siteurl = "http://www.mhsj.top";
        public static ShopConfigInfo ShopConfig = new ShopConfigInfo();

        public string ICP
        {
            get
            {
                return this._icp;
            }
            set
            {
                this._icp = value;
            }
        }

        public int IsLicensed
        {
            get
            {
                return this._islicensed;
            }
            set
            {
                this._islicensed = value;
            }
        }

        public string Script
        {
            get
            {
                return this._script;
            }
            set
            {
                this._script = value;
            }
        }

        public string SEODescription
        {
            get
            {
                return this._seodescription;
            }
            set
            {
                this._seodescription = value;
            }
        }

        public string SEOKeyword
        {
            get
            {
                return this._seokeyword;
            }
            set
            {
                this._seokeyword = value;
            }
        }

        public string ShopName
        {
            get
            {
                return this._shopname;
            }
            set
            {
                this._shopname = value;
            }
        }

        public string SiteTitle
        {
            get
            {
                return this._sitetitle;
            }
            set
            {
                this._sitetitle = value;
            }
        }

        public string SiteUrl
        {
            get
            {
                return this._siteurl;
            }
            set
            {
                this._siteurl = value;
            }
        }
    }
}

