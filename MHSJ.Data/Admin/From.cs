using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class From
    {
        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="_from"></param>
        /// <returns></returns>
        public int InsertFrom(T_From _from)
        {
            string cmdText = @" insert into [T_From](
                                [FromName],[FromAliases],[Description],[DisplayOrder],[CreateDate],[UpdateDate])
                                values (
                                @FromName,@FromAliases,@Description,@DisplayOrder,@CreateDate,@UpdateDate )";
            SqlParameter[] prams =
            {
                new SqlParameter("@FromName", _from.FromName),
                new SqlParameter("@FromAliases", _from.FromAliases),
                new SqlParameter("@Description", _from.Description),
                new SqlParameter("@DisplayOrder", _from.DisplayOrder),
                new SqlParameter("@CreateDate", _from.CreateDate),
                new SqlParameter("@UpdateDate", _from.UpdateDate)
            };
            int r = DbHelperSQL.ExecuteSql(cmdText, prams);
            if (r > 0)
            {
                return
                    Convert.ToInt32(DbHelperSQL.IntExists("select top 1 [FromId] from [T_From]  order by [FromId] desc"));
            }
            return 0;
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="_from"></param>
        /// <returns></returns>
        public int UpdateFrom(T_From _from)
        {
            string cmdText = @"update [T_From] set
                                [FromName]=@FromName,
                                [FromAliases]=@FromAliases,
                                [Description]=@Description,
                                [Displayorder]=@Displayorder,
                                [UpdateDate]=@UpdateDate
                                where FromId=@FromId";
            SqlParameter[] prams =
            {
                new SqlParameter("@FromName", _from.FromName),
                new SqlParameter("@FromAliases", _from.FromAliases),
                new SqlParameter("@Description", _from.Description),
                new SqlParameter("@DisplayOrder", _from.DisplayOrder),
                new SqlParameter("@UpdateDate", _from.UpdateDate),
                new SqlParameter("@FromId", _from.FromId)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteFrom(int id)
        {
            string cmdText = "delete from [T_From] where [FromId] = @FromId";
            SqlParameter[] prams =
            {
                new SqlParameter("@FromId", id)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     获取全部
        /// </summary>
        /// <returns></returns>
        public List<T_From> GetFromList()
        {
            string cmdText = "select * from [T_From] order by  DisplayOrder asc,[Createdate] asc";
            return DataReaderToFromList(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     模糊查询
        /// </summary>
        /// <returns></returns>
        public List<T_From> GetFromList(string name)
        {
            var s = new StringBuilder();
            s.Append("select * from [T_From] ");
            s.AppendFormat(" where FromName like '%{0}%' or FromAliases like '%{0}%'", name);
            s.Append(" order by  DisplayOrder asc,[Createdate] asc");
            return DataReaderToFromList(DbHelperSQL.ExecuteReader(s.ToString()));
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="fromName"></param>
        /// <returns></returns>
        public bool ExistsFromName(string fromName)
        {
            string cmdText = "select count(1) from [T_From] where [FromName] = @FromName ";
            SqlParameter[] prams =
            {
                new SqlParameter("@FromName", SqlDbType.VarChar, 50, fromName)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(cmdText, prams)) > 0;
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private List<T_From> DataReaderToFromList(SqlDataReader read)
        {
            var list = new List<T_From>();
            while (read.Read())
            {
                var frominfo = new T_From();
                frominfo.FromId = Convert.ToInt32(read["FromId"]);
                frominfo.FromName = Convert.ToString(read["FromName"]);
                frominfo.FromAliases = Convert.ToString(read["FromAliases"]);
                frominfo.Description = Convert.ToString(read["Description"]);
                frominfo.DisplayOrder = Convert.ToInt32(read["DisplayOrder"]);
                frominfo.CreateDate = Convert.ToDateTime(read["CreateDate"]);

                list.Add(frominfo);
            }
            read.Close();
            return list;
        }
    }
}