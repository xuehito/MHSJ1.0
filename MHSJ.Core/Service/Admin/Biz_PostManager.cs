using System.Collections.Generic;
using MHSJ.Core.Common;
using MHSJ.Data.Admin;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Admin
{
    public class Biz_PostManager
    {
        public static Biz_PostManager biz_post = new Biz_PostManager();

        /// <summary>
        ///     获取后台文章列表
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public static List<V_Post> QueryList(V_Post item, int pageSize, int pageIndex, out int recordCount)
        {
            return Dac_Post.dac_post.QueryList(item, pageSize, pageIndex, out recordCount);
        }

        /// <summary>
        ///     获取前台文章列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<V_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword, V_Post item)
        {
            return Dac_Post.dac_post.GetPostList(pageSize, pageIndex, out recordCount, keyword, item);
        }

        /// <summary>
        ///     获取前台文章列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <param name="queryType"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<V_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword, int queryType, V_Post item)
        {
            return Dac_Post.dac_post.GetPostList(pageSize, pageIndex, out recordCount, keyword, queryType, item);
        }

        /// <summary>
        ///     添加作品
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InsertPost(T_Post info)
        {
            bool flag = Dac_Post.dac_post.InsertPost(info);
            CacheHelper.Clear();
            return flag;
        }

        /// <summary>
        ///     修改作品
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdatePost(T_Post info)
        {
            bool flag = Dac_Post.dac_post.UpdatePost(info);
            CacheHelper.Clear();
            return flag;
        }

        /// <summary>
        ///     删除作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePost(int id)
        {
            return Dac_Post.dac_post.DeletePost(id);
        }

        /// <summary>
        ///     获取作品列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static List<T_Post> QueryList(T_Post info)
        {
            return Dac_Post.dac_post.QueryList(info);
        }

        /// <summary>
        ///     获取单个作品
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public T_Post GetSinglePost(T_Post info)
        {
            return Dac_Post.dac_post.GetSinglePost(info);
        }

        /// <summary>
        /// 更新浏览次数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateBrowses(T_Post info)
        {
            return Dac_Post.dac_post.UpdateBrowses(info);
        }
    }
}