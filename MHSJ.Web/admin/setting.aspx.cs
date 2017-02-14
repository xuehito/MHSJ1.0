using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MHSJ.Core.Common;
using MHSJ.Core.Service;
using MHSJ.Entity;

namespace MHSJ.Web.admin
{
    public partial class admin_setting : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("网站设置");

            if (!IsPostBack)
            {
                BindSetting();
            }
            Page.MaintainScrollPositionOnPostBack = true;
            ShowResult();
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        protected void ShowResult()
        {
            int result = RequestHelper.QueryInt("result");
            switch (result)
            {
                case 2:
                    ShowMessage("保存成功!");
                    break;

                default:
                    break;
            }
        }

        protected void BindSetting()
        {
            LoadDefaultData();

            SettingInfo s = SettingManager.GetSetting();
            if (s != null)
            {
                txtSiteName.Text = StringHelper.HtmlDecode(s.SiteName);
                txtSiteDescription.Text = StringHelper.HtmlDecode(s.SiteDescription);
                txtMetaKeywords.Text = StringHelper.HtmlDecode(s.MetaKeywords);
                txtMetaDescription.Text = StringHelper.HtmlDecode(s.MetaDescription);
                txtFooterHtml.Text = s.FooterHtml;
            }
        }

        /// <summary>
        /// 加载默认数据
        /// </summary>
        private void LoadDefaultData()
        {

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SettingInfo s = SettingManager.GetSetting();
            if (s != null)
            {
                s.SiteName = StringHelper.HtmlEncode(txtSiteName.Text);
                s.SiteDescription = StringHelper.HtmlEncode(txtSiteDescription.Text);
                s.MetaKeywords = StringHelper.HtmlEncode(txtMetaKeywords.Text);
                s.MetaDescription = StringHelper.HtmlEncode(txtMetaDescription.Text);

                s.FooterHtml = txtFooterHtml.Text;

                if (SettingManager.UpdateSetting())
                {
                    Response.Redirect("setting.aspx?result=2");
                }
            }
        }
    }
}