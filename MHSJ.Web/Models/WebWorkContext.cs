using MHSJ.Core.Config;
using MHSJ.Core.Config.Info;

namespace MHSJ.Web.Models
{
    public class WebWorkContext
    {
        public ShopConfigInfo ShopConfig = BSPConfig.ShopConfig;//配置信息

        public string Avatar; //用户头像
        public string IP; //用户ip
        public string NickName; //用户昵称
        public string Password; //用户密码

        public string SearchWord; //搜索词
        public int Uid = -1; //用户id

        public string Url; //当前url

        public string UrlReferrer; //上一次访问的url

        public string UserEmail; //用户邮箱

        public string UserMobile; //用户手机号
        public string UserName; //用户名
        
    }
}