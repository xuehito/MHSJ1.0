using MHSJ.Data;
using MHSJ.Entity;

namespace MHSJ.Core.Service
{
    /// <summary>
    ///     配置管理
    /// </summary>
    public class SettingManager
    {
        private static readonly Setting Dao = new Setting();

        /// <summary>
        ///     静态变量
        /// </summary>
        private static SettingInfo _setting;

        /// <summary>
        ///     lock
        /// </summary>
        private static readonly object LockHelper = new object();

        static SettingManager()
        {
            LoadSetting();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void LoadSetting()
        {
            if (_setting == null)
            {
                lock (LockHelper)
                {
                    if (_setting == null)
                    {
                        _setting = Dao.GetSetting();
                    }
                }
            }
        }

        /// <summary>
        ///     获取
        /// </summary>
        /// <returns></returns>
        public static SettingInfo GetSetting()
        {
            return _setting;
        }

        /// <summary>
        ///     修改
        /// </summary>
        /// <returns></returns>
        public static bool UpdateSetting()
        {
            return Dao.UpdateSetting(_setting);
        }
    }
}