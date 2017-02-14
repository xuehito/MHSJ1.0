using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Core.Common;
using MHSJ.Data.Admin;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Admin
{
    public class Biz_WordManager
    {
        public static Biz_WordManager biz_word = new Biz_WordManager();

        private const string CacheKey = "_WORDQUERY_";

        /// <summary>
        ///     添加文字
        /// </summary>
        /// <param name="wordInfo"></param>
        /// <returns></returns>
        public bool InsertWord(T_Word wordInfo)
        {
            return Dac_Word.dac_word.InsertWord(wordInfo);
        }

        /// <summary>
        ///     修改文字
        /// </summary>
        /// <param name="wordInfo"></param>
        /// <returns></returns>
        public bool UpdateWord(T_Word wordInfo)
        {
            return Dac_Word.dac_word.UpdateWord(wordInfo);
        }

        /// <summary>
        ///     获取文字列表
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public static List<T_Word> QueryList(T_Word item, int pageSize, int pageIndex, out int recordCount)
        {
            return Dac_Word.dac_word.QueryList(item, pageSize, pageIndex, out recordCount);
        }

        /// <summary>
        ///     获取文字列表
        /// </summary>
        /// <returns></returns>
        public static List<T_Word> QueryList()
        {
            return Dac_Word.dac_word.QueryList();
        }

        /// <summary>
        ///     获取单个汉字
        /// </summary>
        /// <param name="wordId"></param>
        /// <returns></returns>
        public static T_Word GetSingleWord(int wordId)
        {
            return Dac_Word.dac_word.GetSingleWord(wordId);
        }

        /// <summary>
        ///     判断繁体字是否存在
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool ExistsWord(string word)
        {
            return Dac_Word.dac_word.ExistsWord(word);
        }

        /// <summary>
        ///     模糊查询汉字
        /// </summary>
        /// <returns></returns>
        public static List<T_Word> GetWriterList(string name)
        {
            string key = CacheKey + name;

            try
            {
                if (CacheHelper.Get(key) == null)
                {
                    var wordList = Dac_Word.dac_word.QueryList(name);

                    CacheHelper.Insert(key, wordList, 360); //30分钟。

                    return wordList;
                }
                return (List<T_Word>)CacheHelper.Get(key);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        ///     删除汉字
        /// </summary>
        /// <param name="wordId"></param>
        /// <returns></returns>
        public static bool DeleteWord(int wordId)
        {
            return Dac_Word.dac_word.DeleteWord(wordId);
        }
    }
}
