using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class Dac_Word
    {
        public static Dac_Word dac_word = new Dac_Word();

        #region 添加文字

        public bool InsertWord(T_Word wordInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_Word>.Insert_IntoEntities(entities,
                        wordInfo, "T_Word");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 更新文字

        public bool UpdateWord(T_Word wordInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var key = new EntityKey("MHSJEntities.T_Word", "WordId", wordInfo.WordId);
                    Dac_EntityHelper<MHSJEntities, T_Word>.UpdateEntity(entities, wordInfo,
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

        #region 删除文字

        public bool DeleteWord(int wordId)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var item=entities.T_Word.SingleOrDefault(c => c.WordId == wordId);

                    Dac_EntityHelper<MHSJEntities, T_Word>.DeleteEntity(entities, item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 后台查询
        /// <summary>
        ///     后台条件查询
        /// </summary>
        /// <returns></returns>
        public List<T_Word> QueryList(T_Word item, int pageSize, int pageIndex, out int recordCount)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Word> data = entities.T_Word.Where("1 = 1");
                    
                    if (!string.IsNullOrEmpty(item.TraditionalWord))
                    {
                        data = data.Where(c => c.TraditionalWord.Contains(item.TraditionalWord));
                    }
                    if (!string.IsNullOrEmpty(item.SimplifiedWord))
                    {
                        data = data.Where(c => c.SimplifiedWord.Contains(item.SimplifiedWord));
                    }
                    if (!string.IsNullOrEmpty(item.Bushou))
                    {
                        data = data.Where(c => c.Bushou.Contains(item.Bushou));
                    }
                    
                    if (item.State != -1)
                    {
                        data = data.Where(c => c.State == item.State);
                    }
                    recordCount = data.ToList().Count();

                    return data.OrderByDescending(c => c.CreateDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
            }
            catch (Exception exception)
            {
                recordCount = 0;
                return null;
            }
        }

        /// <summary>
        ///     后台条件查询
        /// </summary>
        /// <returns></returns>
        public List<T_Word> QueryList()
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Word> data = entities.T_Word.Where("1 = 1");

                    return data.OrderByDescending(c => c.CreateDate).ToList();
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     后台条件模糊查询
        /// </summary>
        /// <returns></returns>
        public List<T_Word> QueryList(string name)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Word> data = entities.T_Word.Where(a => a.SimplifiedWord.Contains(name) && a.TraditionalWord.Contains(name));

                    if (data.Count() <= 0)
                    {
                        data = entities.T_Word.Where(a => a.SimplifiedWord.Contains(name) || a.TraditionalWord.Contains(name));
                    }

                    return data.OrderByDescending(c => c.CreateDate).ToList();
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        ///     获取单个文字
        /// </summary>
        /// <returns></returns>
        public T_Word GetSingleWord(int wordId)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    return entities.T_Word.SingleOrDefault(c => c.WordId == wordId);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     判断繁体字是否存在
        /// </summary>
        /// <returns></returns>
        public bool ExistsWord(string word)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var data = entities.T_Word.Where(c => c.TraditionalWord == word);
                    
                    if(data.Count()<=0) return false;
                }
            }
            catch (Exception exception)
            {
                return true;
            }

            return true;
        }

        /// <summary>
        ///     根据关键字获取汉字简拼
        /// </summary>
        /// <returns></returns>
        public string GetSingleSW(string key)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    var data = entities.T_Word.Where(c => c.TraditionalWord.Contains(key) || c.SimplifiedWord.Contains(key));
                    if (data.Count()>=0)
                    {
                        return data.ToList()[0].SimplifiedWord;
                    }
                }

                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}