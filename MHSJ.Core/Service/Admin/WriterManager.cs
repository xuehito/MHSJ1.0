using System;
using System.Collections.Generic;
using System.Linq;
using MHSJ.Core.Common;
using MHSJ.Data.Admin;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Admin
{
    partial class StudentCompare : IComparer<T_Writer>
    {
        public int Compare(T_Writer a, T_Writer b)
        {
            return a.DisplayOrder.CompareTo(b.DisplayOrder);
        }
    }

    /// <summary>
    ///     作家管理
    /// </summary>
    public class WriterManager
    {
        private const string CacheKey = "_WRITERQUERY_";
        private static readonly Writer Dao = new Writer();

        /// <summary>
        ///     列表
        /// </summary>
        private static List<T_Writer> _writers;

        /// <summary>
        ///     lock
        /// </summary>
        private static readonly object LockHelper = new object();

        static WriterManager()
        {
            LoadUser();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void LoadUser()
        {
            if (_writers == null)
            {
                lock (LockHelper)
                {
                    if (_writers == null)
                    {
                        _writers = Dao.GetWriterList();
                    }
                }
            }
        }

        /// <summary>
        ///     添加作家
        /// </summary>
        /// <param name="writerinfo"></param>
        /// <returns></returns>
        public static int InsertWriter(T_Writer writerinfo)
        {
            writerinfo.Id = Dao.InsertWriter(writerinfo);
            _writers.Add(writerinfo);
            _writers.Sort(new StudentCompare());

            return writerinfo.Id;
        }

        /// <summary>
        ///     修改作家
        /// </summary>
        /// <param name="writerinfo"></param>
        /// <returns></returns>
        public static int UpdateWriter(T_Writer writerinfo)
        {
            _writers.Sort(new StudentCompare());
            return Dao.UpdateWriter(writerinfo);
        }

        /// <summary>
        ///     获取全部作家
        /// </summary>
        /// <returns></returns>
        public static List<T_Writer> GetWriterList()
        {
            return _writers;
        }

        /// <summary>
        ///     模糊查询作家
        /// </summary>
        /// <returns></returns>
        public static List<T_Writer> GetWriterList(string name)
        {
            string key = CacheKey + name;

            try
            {
                if (CacheHelper.Get(key) == null)
                {
                    var writerList =
                        _writers.Where(a => a.WriterName.Contains(name) || a.WriterAliases.Contains(name) && a.Status==1).ToList();

                    CacheHelper.Insert(key, writerList, 360); //30分钟。

                    return writerList;
                }
                return (List<T_Writer>) CacheHelper.Get(key);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        ///     删除作家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteWriter(int id)
        {
            T_Writer wirter = GetWriter(id);
            if (wirter != null)
            {
                _writers.Remove(wirter);
            }

            return Dao.DeleteWriter(id);
        }

        /// <summary>
        ///     获取作家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_Writer GetWriter(int id)
        {
            return _writers.FirstOrDefault(writer => writer.Id == id);
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="writerName"></param>
        /// <returns></returns>
        public static bool ExistsWriterName(string writerName)
        {
            return Dao.ExistsWriterName(writerName);
        }
    }
}