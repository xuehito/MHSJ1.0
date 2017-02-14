using System;
using System.IO;
using System.Runtime.InteropServices;
using MHSJ.Core.Common;

namespace MHSJ.Web.admin
{
    public partial class admin_default : AdminPage
    {
        #region 变量

        /// <summary>
        ///     CPU信息
        /// </summary>
        protected string CPUInfo;

        /// <summary>
        ///     数据库路径
        /// </summary>
        protected string DbPath;

        /// <summary>
        ///     数据库大小
        /// </summary>
        protected string DbSize;

        /// <summary>
        ///     IIS 版本
        /// </summary>
        protected string IISVersion;

        /// <summary>
        ///     使用内存大小
        /// </summary>
        protected string MemoryInfo;

        /// <summary>
        ///     .net 版本
        /// </summary>
        protected string NETVersion;

        /// <summary>
        ///     操作系统版本
        /// </summary>
        protected string OSVersion;

        /// <summary>
        ///     附件个数
        /// </summary>
        protected int UpfileCount = 0;

        /// <summary>
        ///     附件路径
        /// </summary>
        protected string UpfilePath;

        /// <summary>
        ///     附件大小
        /// </summary>
        protected string UpfileSize;

        #endregion

        /// <summary>
        ///     文件夹大小
        /// </summary>
        public long DirSize = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle("首页");

            if (!IsPostBack)
            {
                DbPath = ConfigHelper.SitePath + ConfigHelper.DbConnection;
                //System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(ConfigHelper.SitePath + ConfigHelper.DbConnection));
                //DbSize = GetFileSize(file.Length);

                UpfilePath = ConfigHelper.SitePath + "upfiles";

                GetDirectorySize(Server.MapPath(UpfilePath));

                UpfileSize = GetFileSize(DirSize);

                GetDirectoryCount(Server.MapPath(UpfilePath));

                GetSystemInfo();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="size">byte</param>
        /// <returns></returns>
        protected string GetFileSize(long size)
        {
            string FileSize = string.Empty;
            if (size > (1024*1024*1024))
                FileSize = ((double) size/(1024*1024*1024)).ToString(".##") + " GB";
            else if (size > (1024*1024))
                FileSize = ((double) size/(1024*1024)).ToString(".##") + " MB";
            else if (size > 1024)
                FileSize = ((double) size/1024).ToString(".##") + " KB";
            else if (size == 0)
                FileSize = "0 Byte";
            else
                FileSize = ((double) size/1).ToString(".##") + " Byte";

            return FileSize;
        }

        /// <summary>
        ///     递归文件夹大小
        /// </summary>
        /// <param name="dirp"></param>
        /// <returns></returns>
        private long GetDirectorySize(string dirp)
        {
            var mydir = new DirectoryInfo(dirp);
            foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {
                    var fi = (FileInfo) fsi;
                    DirSize += fi.Length;
                }
                else
                {
                    var di = (DirectoryInfo) fsi;
                    string new_dir = di.FullName;
                    GetDirectorySize(new_dir);
                }
            }
            return DirSize;
        }


        /// <summary>
        ///     递归文件数量
        /// </summary>
        /// <param name="dirp"></param>
        /// <returns></returns>
        private int GetDirectoryCount(string dirp)
        {
            var mydir = new DirectoryInfo(dirp);
            foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {
                    //   FileInfo fi = (FileInfo)fsi;
                    UpfileCount += 1;
                }
                else
                {
                    var di = (DirectoryInfo) fsi;
                    string new_dir = di.FullName;
                    GetDirectoryCount(new_dir);
                }
            }
            return UpfileCount;
        }

        /// <summary>
        ///     获取系统内存大小
        /// </summary>
        /// <returns>内存大小（单位GB）</returns>
        private static int GetPhisicalMemory()
        {
            //try
            //{
            //    ManagementObjectSearcher searcher = new ManagementObjectSearcher();   //用于查询一些如系统信息的管理对象 
            //    searcher.Query = new SelectQuery("Win32_PhysicalMemory ", "", new string[] { "Capacity" });//设置查询条件 
            //    ManagementObjectCollection collection = searcher.Get();   //获取内存容量 
            //    ManagementObjectCollection.ManagementObjectEnumerator em = collection.GetEnumerator();

            //    long capacity = 0;
            //    while (em.MoveNext())
            //    {
            //        ManagementBaseObject baseObj = em.Current;
            //        if (baseObj.Properties["Capacity"].Value != null)
            //        {
            //            try
            //            {
            //                capacity += long.Parse(baseObj.Properties["Capacity"].Value.ToString());
            //            }
            //            catch
            //            {
            //                return 0;
            //            }
            //        }
            //    }
            //    return (int)(capacity / 1024 / 1024 / 1024);
            //}
            //catch
            //{
            //    return 0;
            //}
            return 0;
        }

        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);

        //定义内存的信息结构   

        /// <summary>
        ///     获取系统信息
        /// </summary>
        protected void GetSystemInfo()
        {
            try
            {
                OSVersion = Environment.OSVersion.ToString();

                IISVersion = Request.ServerVariables["SERVER_SOFTWARE"];

                if (OSVersion.IndexOf("Microsoft Windows NT 5.0") > -1)
                {
                    OSVersion = string.Concat("Microsoft Windows 2000 (", OSVersion, ")");
                    IISVersion = "IIS 5";
                }
                else if (OSVersion.IndexOf("Microsoft Windows NT 5.1") > -1)
                {
                    OSVersion = string.Concat("Microsoft Windows XP (", OSVersion, ")");
                    IISVersion = "IIS 5.1";
                }
                else if (OSVersion.IndexOf("Microsoft Windows NT 5.2") > -1)
                {
                    OSVersion = string.Concat("Microsoft Windows 2003 (", OSVersion, ")");
                    IISVersion = "IIS 6";
                }
                else if (OSVersion.IndexOf("Microsoft Windows NT 6.0") > -1)
                {
                    OSVersion = string.Concat("Microsoft Windows Vista or Server 2008 (", OSVersion, ")");
                    IISVersion = "IIS 7";
                }
                else if (OSVersion.IndexOf("Microsoft Windows NT 6.1") > -1)
                {
                    OSVersion = string.Concat("Microsoft Windows 7 or Server 2008 R2 (", OSVersion, ")");
                    IISVersion = "IIS 7.5";
                }

                NETVersion = Environment.Version.ToString();

                CPUInfo = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") + " (" + Environment.ProcessorCount +
                          " 核)";


                MEMORY_INFO MemInfo;
                MemInfo = new MEMORY_INFO();
                GlobalMemoryStatus(ref MemInfo);


                MemoryInfo = "物理内存:" + (MemInfo.dwTotalPhys/1024/1024) + " MB / 当前程序已占用物理内存:" +
                             (Environment.WorkingSet/1024/1024) + " MB";
            }
            catch
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }
    }
}