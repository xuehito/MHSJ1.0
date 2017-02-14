using System.Collections.Generic;
using System.Linq;
using MHSJ.Core.Common;
using MHSJ.Data.Admin;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Admin
{
    partial class StudentCompare : IComparer<T_From>
    {
        public int Compare(T_From a, T_From b)
        {
            return a.DisplayOrder.CompareTo(b.DisplayOrder);
        }
    }

    /// <summary>
    ///     出处管理
    /// </summary>
    public class FromManager
    {
        private const string CacheKey = "_FROMQUERY_";
        private static readonly From Dao = new From();

        /// <summary>
        ///     列表
        /// </summary>
        private static List<T_From> _froms;

        /// <summary>
        ///     lock
        /// </summary>
        private static readonly object LockHelper = new object();

        static FromManager()
        {
            LoadFrom();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void LoadFrom()
        {
            if (_froms == null)
            {
                lock (LockHelper)
                {
                    if (_froms == null)
                    {
                        _froms = Dao.GetFromList();
                    }
                }
            }
        }

        /// <summary>
        ///     添加出处
        /// </summary>
        /// <param name="frominfo"></param>
        /// <returns></returns>
        public static int InsertFrom(T_From frominfo)
        {
            frominfo.FromId = Dao.InsertFrom(frominfo);
            _froms.Add(frominfo);
            _froms.Sort(new StudentCompare());

            return frominfo.FromId;
        }

        /// <summary>
        ///     修改用户
        /// </summary>
        /// <param name="frominfo"></param>
        /// <returns></returns>
        public static int UpdateFrom(T_From frominfo)
        {
            _froms.Sort(new StudentCompare());
            return Dao.UpdateFrom(frominfo);
        }

        /// <summary>
        ///     获取全部出处
        /// </summary>
        /// <returns></returns>
        public static List<T_From> GetFromList()
        {
            return _froms;
        }

        /// <summary>
        ///     模糊查询出处
        /// </summary>
        /// <returns></returns>
        public static List<T_From> GetFromList(string name)
        {
            string key = CacheKey + name;

            if (CacheHelper.Get(key) == null)
            {
                var fromList =
                       _froms.Where(a => a.FromName.Contains(name) || a.FromAliases.Contains(name)).ToList();

                CacheHelper.Insert(key, fromList, 360); //30分钟。

                return fromList;
            }

            return (List<T_From>) CacheHelper.Get(key);
        }

        /// <summary>
        ///     删除出处
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteFrom(int id)
        {
            T_From wirter = GetFrom(id);
            if (wirter != null)
            {
                _froms.Remove(wirter);
            }

            return Dao.DeleteFrom(id);
        }

        /// <summary>
        ///     获取出处
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_From GetFrom(int id)
        {
            return _froms.FirstOrDefault(from => from.FromId == id);
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="fromName"></param>
        /// <returns></returns>
        public static bool ExistsFromName(string fromName)
        {
            return Dao.ExistsFromName(fromName);
        }
    }
}