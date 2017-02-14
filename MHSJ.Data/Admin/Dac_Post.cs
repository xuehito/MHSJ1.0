using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class Dac_Post
    {
        public static Dac_Post dac_post = new Dac_Post();

        /// <summary>
        ///     后台条件查询
        /// </summary>
        /// <returns></returns>
        public List<V_Post> QueryList(V_Post item, int pageSize, int pageIndex, out int recordCount)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<V_Post> data = entities.V_Post.Where("1 = 1");
                    if (!string.IsNullOrEmpty(item.WriterName))
                    {
                        data = data.Where(c => c.WriterName.Contains(item.WriterName));
                    }
                    if (!string.IsNullOrEmpty(item.TraditionalWord))
                    {
                        data = data.Where(c => c.Tword.Contains(item.TraditionalWord));
                    }
                    if (!string.IsNullOrEmpty(item.SimplifiedWord))
                    {
                        data = data.Where(c => c.SimplifiedWord.Contains(item.SimplifiedWord));
                    }
                    if (!string.IsNullOrEmpty(item.Bushou))
                    {
                        data = data.Where(c => c.Bushou.Contains(item.Bushou));
                    }
                    if (!string.IsNullOrEmpty(item.FromName))
                    {
                        data = data.Where(c => c.FromName.Contains(item.FromName));
                    }
                    if (!string.IsNullOrEmpty(item.WordTypeName))
                    {
                        data = data.Where(c => c.WordTypeName.Contains(item.WordTypeName));
                    }
                    if (!string.IsNullOrEmpty(item.WordDirection) && item.WordDirection != "0")
                    {
                        data = data.Where(c => c.WordDirection == item.WordDirection);
                    }
                    if (item.State != -1)
                    {
                        data = data.Where(c => c.State == item.State);
                    }
                    recordCount = data.ToList().Count();

                    return data.OrderByDescending(c => c.CreateDate).Skip(pageSize*(pageIndex - 1)).Take(pageSize).ToList();
                }
            }
            catch (Exception exception)
            {
                recordCount = 0;
                return null;
            }
        }

        /// <summary>
        ///     首页条件查询--查询有点问题
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<V_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword, V_Post item)
        {
            using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
            {
                IQueryable<V_Post> data = entities.V_Post.Where("1 = 1");

                if (!string.IsNullOrEmpty(item.WriterName))
                {
                    string[] wirterNames = item.WriterName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    data = wirterNames.Aggregate(data,
                        (current, name) => current.Where(c => c.WriterName.Contains(name)));
                }

                if (!string.IsNullOrEmpty(item.FromName))
                {
                    string[] fromNames = item.FromName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    data = fromNames.Aggregate(data, (current, name) => current.Where(c => c.FromName.Contains(name)));
                }

                if (!string.IsNullOrEmpty(item.WordType))
                {
                    string[] wirterTypes = item.WordType.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    data = wirterTypes.Aggregate(data, (current, type) => current.Where(c => c.WordType == type));
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    data = data.Where(c => c.SimplifiedWord.Contains(keyword) || c.TraditionalWord.Contains(keyword));
                }

                if (item.WordDirection != null && item.WordDirection != "0")
                {
                    if (!string.IsNullOrEmpty(item.WordType))
                    {
                        string[] wirterTypes = item.WordType.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        string[] dires = item.WordDirection.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string wirterType in wirterTypes)
                        {
                            if (Convert.ToInt32(wirterType) >= 14 && Convert.ToInt32(wirterType) <= 20)
                            {
                                string type = wirterType;
                                data = data.Where(c => c.WordType == type && c.WordDirection == dires[0]);
                            }
                            if (Convert.ToInt32(wirterType) >= 21 && Convert.ToInt32(wirterType) <= 26)
                            {
                                if (dires[1] == "3" || dires[1] == "4")
                                {
                                    string di = "";

                                    if (dires[1] == "3") di = "1";
                                    if (dires[1] == "4") di = "2";

                                    data =
                                        data.Where(
                                            c => c.WordType == di && c.WordDirection == dires[1]);
                                }
                            }
                        }
                    }
                }

                recordCount = data.ToList().Count();

                return data.OrderByDescending(c => c.CreateDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
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
        public List<V_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword, int queryType, V_Post item)
        {
            var simplifiedWord = Dac_Word.dac_word.GetSingleSW(keyword);//获取汉字简拼
           
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
                string[] wirterNames = item.WriterName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                string[] fromNames = item.FromName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                string[] wirterTypes = item.WordType.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                string[] wordTypeNames = item.WordTypeName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                    if (string.IsNullOrEmpty(simplifiedWord))
                    {
                        condition +=
                                string.Format(
                                    " and (TWord like '%{0}%')",
                                    keyword);
                    }
                    else
                    {
                        if (simplifiedWord.Contains(keyword))
                        {
                            condition +=
                                string.Format(
                                    " and (SimplifiedWord like '%{0}%' or Tword like '%{0}%')",
                                    keyword);
                        }
                        else
                        {
                            condition +=
                                string.Format(
                                    " and ((SimplifiedWord like '%{0}%' and TWord like '%{1}%' ) or (SimplifiedWord like '%{0}%' and TWord like '%{0}%'))",
                                    simplifiedWord, keyword);
                        }
                    }
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
                    string[] wirterTypes = item.WordType.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] dires = item.WordDirection.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

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

            string cmdTotalRecord = "select count(1) from [V_Post] where " + condition;

            recordCount = DbHelperSQL.IntExists(cmdTotalRecord);

            string cmdText = DbHelperSQL.GetPageSql("[V_Post]", "[PostId]", "*", pageSize, pageIndex, 1, condition);

            return DataReaderToPostList(DbHelperSQL.ExecuteReader(cmdText));
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private List<V_Post> DataReaderToPostList(SqlDataReader read)
        {
            var list = new List<V_Post>();
            while (read.Read())
            {
                var postinfo = new V_Post();
                postinfo.PostId = Convert.ToInt32(read["PostId"]);
                postinfo.SimplifiedWord = Convert.ToString(read["SimplifiedWord"]);
                postinfo.TraditionalWord = Convert.ToString(read["TraditionalWord"]);
                postinfo.Tword = Convert.ToString(read["Tword"]);
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


        #region 添加作品

        public bool InsertPost(T_Post info)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_Post>.Insert_IntoEntities(entities,
                        info, "T_Post");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 更新作品

        public bool UpdatePost(T_Post info)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var key = new EntityKey("MHSJEntities.T_Post", "PostId", info.PostId);
                    Dac_EntityHelper<MHSJEntities, T_Post>.UpdateEntity(entities, info,
                        key, false);

                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 删除作品

        public bool DeletePost(int id)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var item = entities.T_Post.SingleOrDefault(c => c.PostId == id);

                    Dac_EntityHelper<MHSJEntities, T_Post>.DeleteEntity(entities, item);

                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion


        /// <summary>
        ///     获取作品列表
        /// </summary>
        /// <returns></returns>
        public List<T_Post> QueryList(T_Post info)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Post> data = entities.T_Post.Where("1 = 1").Where(c=>c.TWord==null && c.TraditionalWord!="");
                    if (!string.IsNullOrEmpty(info.SimplifiedWord))
                    {
                        data = data.Where(c => c.SimplifiedWord == info.SimplifiedWord);
                    }

                    return data.ToList();
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     获取单个作品
        /// </summary>
        /// <returns></returns>
        public T_Post GetSinglePost(T_Post info)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    return entities.T_Post.SingleOrDefault(c => c.PostId == info.PostId);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}