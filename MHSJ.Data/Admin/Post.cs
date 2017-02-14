using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class Post
    {
        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int InsertPost(T_Post post)
        {
            string cmdText = @" insert into [T_Post](
                                [SimplifiedWord],[TraditionalWord],[Pinyin],[Wubi],[Changjei],[Zhengma],
[Bushou],[Tongjia],[Yiti],[WordType],[WordTypeName],[WordDirection],[WriterName],[WriterId],[FromName],[FromId],[ImageUrl],[State],
[CreateDate],[UpdateDate])
                                values (
                                @SimplifiedWord,@TraditionalWord,@Pinyin,@Wubi,@Changjei,@Zhengma,
@Bushou,@Tongjia,@Yiti,@WordType,@WordTypeName,@WordDirection,@WriterName,@WriterId,@FromName,@FromId,@ImageUrl,@State,
@CreateDate,@UpdateDate )";
            SqlParameter[] prams =
            {
                new SqlParameter("@SimplifiedWord", post.SimplifiedWord),
                new SqlParameter("@TraditionalWord", post.TraditionalWord),
                new SqlParameter("@Pinyin", post.Pinyin),
                new SqlParameter("@Wubi", post.Wubi),
                new SqlParameter("@Changjei", post.Changjei),
                new SqlParameter("@Zhengma", post.Zhengma),
                new SqlParameter("@Bushou", post.Bushou),
                new SqlParameter("@Tongjia", post.Tongjia),
                new SqlParameter("@Yiti", post.Yiti),
                new SqlParameter("@WordType", post.WordType),
                new SqlParameter("@WordTypeName", post.WordTypeName),
                new SqlParameter("@WordDirection", post.WordDirection),
                new SqlParameter("@WriterName", post.WriterName),
                new SqlParameter("@WriterId", post.WriterId),
                new SqlParameter("@FromName", post.FromName),
                new SqlParameter("@FromId", post.FromId),
                new SqlParameter("@ImageUrl", post.ImageUrl),
                new SqlParameter("@State", post.State),
                new SqlParameter("@CreateDate", post.CreateDate),
                new SqlParameter("@UpdateDate", post.UpdateDate)
            };
            int r = DbHelperSQL.ExecuteSql(cmdText, prams);
            if (r > 0)
            {
                return
                    Convert.ToInt32(DbHelperSQL.IntExists("select top 1 [PostId] from [T_Post]  order by [PostId] desc"));
            }
            return 0;
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int UpdatePost(T_Post post)
        {
            string cmdText = @"update [T_Post] set
                                [SimplifiedWord]=@SimplifiedWord,
                                [TraditionalWord]=@TraditionalWord,
                                [Pinyin]=@Pinyin,
                                [Wubi]=@Wubi,
                                [Changjei]=@Changjei,
                                [Zhengma]=@Zhengma,
                                [Bushou]=@Bushou,
                                [Tongjia]=@Tongjia,
                                [Yiti]=@Yiti,
                                [WordType]=@WordType,
                                [WordTypeName]=@WordTypeName,
                                [WordDirection]=@WordDirection,
                                [WriterName]=@WriterName,
                                [WriterId]=@WriterId,
                                [FromName]=@FromName,
                                [FromId]=@FromId,
                                [ImageUrl]=@ImageUrl,
                                [State]=@State,
                                [UpdateDate]=@UpdateDate
                                where PostId=@PostId";
            SqlParameter[] prams =
            {
                new SqlParameter("@SimplifiedWord", post.SimplifiedWord),
                new SqlParameter("@TraditionalWord", post.TraditionalWord),
                new SqlParameter("@Pinyin", post.Pinyin),
                new SqlParameter("@Wubi", post.Wubi),
                new SqlParameter("@Changjei", post.Changjei),
                new SqlParameter("@Zhengma", post.Zhengma),
                new SqlParameter("@Bushou", post.Bushou),
                new SqlParameter("@Tongjia", post.Tongjia),
                new SqlParameter("@Yiti", post.Yiti),
                new SqlParameter("@WordType", post.WordType),
                new SqlParameter("@WordTypeName", post.WordTypeName),
                new SqlParameter("@WordDirection", post.WordDirection),
                new SqlParameter("@WriterName", post.WriterName),
                new SqlParameter("@WriterId", post.WriterId),
                new SqlParameter("@FromName", post.FromName),
                new SqlParameter("@FromId", post.FromId),
                new SqlParameter("@ImageUrl", post.ImageUrl),
                new SqlParameter("@State", post.State),
                new SqlParameter("@UpdateDate", post.UpdateDate),
                new SqlParameter("@PostId", post.PostId)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePost(int id)
        {
            string cmdText = "delete from [T_Post] where [PostId] = @PostId";
            SqlParameter[] prams =
            {
                new SqlParameter("@PostId", id)
            };
            return DbHelperSQL.ExecuteSql(cmdText, prams);
        }

        /// <summary>
        ///     获取全部
        /// </summary>
        /// <returns></returns>
        public List<T_Post> GetPostList()
        {
            string cmdText = "select * from [T_Post] order by [Createdate] asc";
            return DataReaderToPostList(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     获取最后一个文章
        /// </summary>
        /// <returns></returns>
        public T_Post GetLastPost()
        {
            string cmdText = "select top 1 * from [T_Post] order by [Createdate] desc";
            return DataReaderToPost(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     首页条件查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <param name="queryType">1:汉字查询2:部首查询</param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<T_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword,int queryType, T_Post item)
        {
            string condition = " 1=1 ";

            //if (!string.IsNullOrEmpty(begindate))
            //{
            //    condition += " and createdate>=#" + begindate + "#";
            //}
            //if (!string.IsNullOrEmpty(enddate))
            //{
            //    condition += " and createdate<#" + enddate + "#";
            //}
            if (!string.IsNullOrEmpty(item.WriterName))
            {
                string[] wirterNames = item.WriterName.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (wirterNames.Count() >= 1)
                {
                    condition += " and ( ";
                    for (int a = 0; a < wirterNames.Count(); a++)
                    {
                        if (a > 0) condition += " or ";
                        condition += string.Format("  WriterName like '%{0}%'", wirterNames[a]);
                    }
                    condition += " )";
                }
            }
            if (!string.IsNullOrEmpty(item.FromName))
            {
                string[] fromNames = item.FromName.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (fromNames.Count() >= 1)
                {
                    condition += " and ( ";
                    for (int a = 0; a < fromNames.Count(); a++)
                    {
                        if (a > 0) condition += " or ";
                        condition += string.Format("  FromName like '%{0}%'", fromNames[a]);
                    }
                    condition += " )";
                }
            }
            if (!string.IsNullOrEmpty(item.WordType))
            {
                string[] wirterTypes = item.WordType.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (wirterTypes.Count() >= 1)
                {
                    condition += " and (";
                    for (int a = 0; a < wirterTypes.Count(); a++)
                    {
                        if (a > 0) condition += " or ";
                        condition += string.Format("  WordType={0}", wirterTypes[a]);
                    }
                    condition += " )";
                }
            }
            if (!string.IsNullOrEmpty(item.WordTypeName))
            {
                string[] wordTypeNames = item.WordTypeName.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (wordTypeNames.Count() >= 1)
                {
                    condition += " and ( ";
                    for (int a = 0; a < wordTypeNames.Count(); a++)
                    {
                        if (a > 0) condition += " or ";
                        condition += string.Format("  WordTypeName like '%{0}%'", wordTypeNames[a]);
                    }
                    condition += " )";
                }
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                if (queryType == 1 || queryType == 0)
                {
                    condition +=
                        string.Format(
                            " and (SimplifiedWord like '%{0}%' or TraditionalWord like '%{0}%' )",
                            keyword);
                }
                else if (queryType == 2)
                {
                    condition +=
                        string.Format(
                            " and (Bushou like '%{0}%')",
                            keyword);
                }
            }
            
            //if (!string.IsNullOrEmpty(item.SimplifiedWord))
            //{
            //    condition +=
            //        string.Format(
            //            " and (SimplifiedWord like '%{0}%' )",
            //            item.SimplifiedWord);
            //}
            //if (!string.IsNullOrEmpty(item.TraditionalWord))
            //{
            //    condition +=
            //        string.Format(
            //            " and (TraditionalWord like '%{0}%' )",
            //            item.TraditionalWord);
            //}
            if (item.WordDirection != null && item.WordDirection != "0")
            {
                condition += "and ( ";

                condition += string.Format(" WordDirection='0' or WordDirection='{0}'", item.WordDirection[0]);

                if (!string.IsNullOrEmpty(item.WordType))
                {
                    string[] wirterTypes = item.WordType.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    string[] dires = item.WordDirection.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < wirterTypes.Length; i++)
                    {
                        if (Convert.ToInt32(wirterTypes[i]) >= 14 && Convert.ToInt32(wirterTypes[i]) <= 20)
                        {
                            condition += "or  ";

                            condition +=
                                string.Format(" (WordType>='{0}' and WordType<='{1}' ", "14", "20");

                            condition +=
                                string.Format(" and WordDirection='{0}')", dires[0]);
                        }

                        if (Convert.ToInt32(wirterTypes[i]) >= 21 && Convert.ToInt32(wirterTypes[i]) <= 26)
                        {
                            condition += "or  ";

                            condition +=
                                string.Format(" (WordType>='{0}' and WordType<='{1}' ", "21", "26");

                            if (dires[1] == "3" || dires[1] == "4")
                            {
                                string di = "";

                                if (dires[1] == "3") di = "1";
                                if (dires[1] == "4") di = "2";
                                condition +=
                                    string.Format(" and  WordDirection='{0}')", di);
                            }
                        }
                    }
                }

                condition += ")";
            }

            string cmdTotalRecord = "select count(1) from [T_Post] where " + condition;

            recordCount = DbHelperSQL.IntExists(cmdTotalRecord);

            string cmdText = DbHelperSQL.GetPageSql("[T_Post]", "[PostId]", "*", pageSize, pageIndex, 1, condition);

            return DataReaderToPostList(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="postName"></param>
        /// <returns></returns>
        public
            bool ExistsPostName
            (string
                postName)
        {
            string cmdText = "select count(1) from [T_Post] where [PostName] = @PostName ";
            SqlParameter[] prams =
            {
                new SqlParameter("@PostName", SqlDbType.VarChar, 50, postName)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(cmdText, prams)) > 0;
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private  List<T_Post> DataReaderToPostList (SqlDataReader read)
        {
            var list = new List<T_Post>();
            while (read.Read())
            {
                var postinfo = new T_Post();
                postinfo.PostId = Convert.ToInt32(read["PostId"]);
                postinfo.SimplifiedWord = Convert.ToString(read["SimplifiedWord"]);
                postinfo.TraditionalWord = Convert.ToString(read["TraditionalWord"]);
                postinfo.Pinyin = Convert.ToString(read["Pinyin"]);
                postinfo.Wubi = Convert.ToString(read["Wubi"]);
                postinfo.Changjei = Convert.ToString(read["Changjei"]);
                postinfo.Zhengma = Convert.ToString(read["Zhengma"]);
                postinfo.Bushou = Convert.ToString(read["Bushou"]);
                postinfo.Tongjia = Convert.ToString(read["Tongjia"]);
                postinfo.Yiti = Convert.ToString(read["Yiti"]);
                postinfo.WordType = Convert.ToString(read["WordType"]);
                postinfo.WordTypeName = Convert.ToString(read["WordTypeName"]);
                postinfo.WordDirection = read["WordDirection"] == null ? "0" : read["WordDirection"].ToString();
                postinfo.ImageUrl = Convert.ToString(read["ImageUrl"]);
                postinfo.WriterName = Convert.ToString(read["WriterName"]);
                postinfo.WriterId = read["WriterId"] == null ? 0 : Convert.ToInt32(read["WriterId"]);
                postinfo.FromName = Convert.ToString(read["FromName"]);
                postinfo.FromId = read["FromId"] == null ? 0 : Convert.ToInt32(read["FromId"]);
                postinfo.CreateDate = Convert.ToDateTime(read["CreateDate"]);

                list.Add(postinfo);
            }
            read.Close();
            return list;
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private
            T_Post DataReaderToPost
            (SqlDataReader
                read)
        {
            var postinfo = new T_Post();

            while (read.Read())
            {
                postinfo.PostId = Convert.ToInt32(read["PostId"]);
                postinfo.SimplifiedWord = Convert.ToString(read["SimplifiedWord"]);
                postinfo.TraditionalWord = Convert.ToString(read["TraditionalWord"]);
                postinfo.Pinyin = Convert.ToString(read["Pinyin"]);
                postinfo.Wubi = Convert.ToString(read["Wubi"]);
                postinfo.Changjei = Convert.ToString(read["Changjei"]);
                postinfo.Zhengma = Convert.ToString(read["Zhengma"]);
                postinfo.Bushou = Convert.ToString(read["Bushou"]);
                postinfo.Tongjia = Convert.ToString(read["Tongjia"]);
                postinfo.Yiti = Convert.ToString(read["Yiti"]);
                postinfo.WordType = Convert.ToString(read["WordType"]);
                postinfo.WordTypeName = Convert.ToString(read["WordTypeName"]);
                postinfo.WordDirection = read["WordDirection"] == null ? "0" : read["WordDirection"].ToString();
                postinfo.ImageUrl = Convert.ToString(read["ImageUrl"]);
                postinfo.WriterName = Convert.ToString(read["WriterName"]);
                postinfo.WriterId = read["WriterId"] == null ? 0 : Convert.ToInt32(read["WriterId"]);
                postinfo.FromName = Convert.ToString(read["FromName"]);
                postinfo.FromId = read["FromId"] == null ? 0 : Convert.ToInt32(read["FromId"]);
                postinfo.CreateDate = Convert.ToDateTime(read["CreateDate"]);
            }
            read.Close();
            return postinfo;
        }
    }
}