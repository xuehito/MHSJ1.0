using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MHSJ.Core.Data.Interface;

namespace MHSJ.Core.Data
{
    public sealed class DataSql
    {
         private static readonly string path = "MHSJ.Data";

        private static object lockHelper = new object();

        public static IUser _iuser = null;

        private DataSql() { }

        public static IUser CreateUser()
        {
            string className = path + ".User";
          //  return (IUser)Assembly.Load(path).CreateInstance(className);
            return CreateInstance<IUser>(_iuser, className);
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_instance"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(T _instance, string className)
        {

            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = (T)Assembly.Load(path).CreateInstance(className);
                    }
                }
            }
            return _instance;

        }
    }
}
