using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class Writer
    {
        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public int InsertWriter(T_Writer writer)
        {
            string cmdText = @" insert into [T_Writer](
                                [WriterName],[WriterAliases],[Dynasty],[Description],[DisplayOrder],[Status],[CreateDate])
                                values (
                                @WriterName,@WriterAliases,@Dynasty,@Description,@DisplayOrder,@Status,@CreateDate )";
            SqlParameter[] prams =
            {
                new SqlParameter("@WriterName", writer.WriterName),
                new SqlParameter("@WriterAliases", writer.WriterAliases),
                new SqlParameter("@Dynasty", writer.Dynasty),
                new SqlParameter("@Description", writer.Description),
                new SqlParameter("@DisplayOrder", writer.DisplayOrder),
                new SqlParameter("@Status", writer.Status),
                new SqlParameter("@CreateDate", writer.CreateDate)
            };
            int r = DbHelperSQL.ExecuteSql(cmdText, prams);
            if (r > 0)
            {
                return Convert.ToInt32(DbHelperSQL.IntExists("select top 1 [Id] from [T_Writer]  order by [Id] desc"));
            }
            return 0;
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public int UpdateWriter(T_Writer writer)
        {
            string cmdText = @"update [T_Writer] set
                                [WriterName]=@WriterName,
                                [WriterAliases]=@WriterAliases,
                                [Dynasty]=@Dynasty,
                                [Description]=@Description,
                                [Displayorder]=@Displayorder,
                                [Status]=@Status,
                                [UpdateDate]=@UpdateDate
                                where Id=@Id";
            SqlParameter[] prams =
            {
                new SqlParameter("@WriterName", writer.WriterName),
                new SqlParameter("@WriterAliases", writer.WriterAliases),
                new SqlParameter("@Dynasty", writer.Dynasty),
                new SqlParameter("@Description", writer.Description),
                new SqlParameter("@DisplayOrder", writer.DisplayOrder),
                new SqlParameter("@Status", writer.Status),
                new SqlParameter("@UpdateDate", writer.UpdateDate),
                new SqlParameter("@Id", writer.Id)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteWriter(int id)
        {
            string cmdText = "delete from [T_Writer] where [Id] = @Id";
            SqlParameter[] prams =
            {
                new SqlParameter("@Id", id)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     获取全部
        /// </summary>
        /// <returns></returns>
        public List<T_Writer> GetWriterList()
        {
            string cmdText = "select * from [T_Writer] order by  DisplayOrder asc,[Createdate] asc";
            return DataReaderToWriterList(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     模糊查询
        /// </summary>
        /// <returns></returns>
        public List<T_Writer> GetWriterList(string name)
        {
            var s = new StringBuilder();
            s.Append("select * from [T_Writer] ");
            s.AppendFormat(" where WriterName like '%{0}%' or WriterAliases like '%{0}%'", name);
            s.Append(" order by  DisplayOrder asc,[Createdate] asc");
            return DataReaderToWriterList(DbHelperSQL.ExecuteReader(s.ToString()));
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="writerName"></param>
        /// <returns></returns>
        public bool ExistsWriterName(string writerName)
        {
            string cmdText = "select count(1) from [T_Writer] where [WriterName] = @WriterName ";
            SqlParameter[] prams =
            {
                new SqlParameter("@WriterName", SqlDbType.VarChar, 50, writerName)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(cmdText, prams)) > 0;
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private List<T_Writer> DataReaderToWriterList(SqlDataReader read)
        {
            var list = new List<T_Writer>();
            while (read.Read())
            {
                var writerinfo = new T_Writer();
                writerinfo.Id = Convert.ToInt32(read["Id"]);
                writerinfo.WriterName = Convert.ToString(read["WriterName"]);
                writerinfo.WriterAliases = Convert.ToString(read["WriterAliases"]);
                writerinfo.Dynasty = Convert.ToString(read["Dynasty"]);
                writerinfo.Description = Convert.ToString(read["Description"]);
                writerinfo.DisplayOrder = Convert.ToInt32(read["DisplayOrder"]);
                writerinfo.Status = Convert.ToInt32(read["Status"]);
                writerinfo.CreateDate = Convert.ToDateTime(read["CreateDate"]);

                list.Add(writerinfo);
            }
            read.Close();
            return list;
        }
    }
}