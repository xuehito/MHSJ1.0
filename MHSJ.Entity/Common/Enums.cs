namespace MHSJ.Entity.Common
{
    /// <summary>
    ///     用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        ///     管理员
        /// </summary>
        Administrator = 1,
        
        /// <summary>
        ///     写作者
        /// </summary>
        Author = 5,

        /// <summary>
        ///     超级管理员
        /// </summary>
        SuperAdministrator = 8
    }

    public enum WordType
    {
        /// <summary>
        /// 楷书-大楷
        /// </summary>
        Daka=1,
        /// <summary>
        /// 楷书-小楷
        /// </summary>
        Xiaoka=2,
        /// <summary>
        /// 楷书-魏碑
        /// </summary>
        Weibei=3,
    }
}