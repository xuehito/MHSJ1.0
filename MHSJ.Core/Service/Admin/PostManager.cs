using System.Collections.Generic;
using System.Linq;
using MHSJ.Data.Admin;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Admin
{
    partial class StudentCompare : IComparer<T_Post>
    {
        public int Compare(T_Post a, T_Post b)
        {
            return a.PostId.CompareTo(b.PostId);
        }
    }

    /// <summary>
    ///     作品管理
    /// </summary>
    public class PostManager
    {
        private static readonly Post Dao = new Post();

        /// <summary>
        ///     列表
        /// </summary>
        private static List<T_Post> _posts;

        /// <summary>
        ///     lock
        /// </summary>
        private static readonly object LockHelper = new object();

        static PostManager()
        {
            LoadPost();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void LoadPost()
        {
            if (_posts == null)
            {
                lock (LockHelper)
                {
                    if (_posts == null)
                    {
                        _posts = Dao.GetPostList();
                    }
                }
            }
        }

        /// <summary>
        ///     添加作品
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static int InsertPost(T_Post post)
        {
            post.PostId = Dao.InsertPost(post);
            _posts.Add(post);
            _posts.Sort(new StudentCompare());

            return post.PostId;
        }

        /// <summary>
        ///     修改作品
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static int UpdatePost(T_Post post)
        {
            _posts.Sort(new StudentCompare());
            return Dao.UpdatePost(post);
        }

        /// <summary>
        ///     获取全部作品
        /// </summary>
        /// <returns></returns>
        public static List<T_Post> GetPostList()
        {
            return _posts;
        }

        /// <summary>
        ///     删除作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeletePost(int id)
        {
            T_Post wirter = GetPost(id);
            if (wirter != null)
            {
                _posts.Remove(wirter);
            }

            return Dao.DeletePost(id);
        }

        /// <summary>
        ///     获取作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_Post GetPost(int id)
        {
            return _posts.FirstOrDefault(post => post.PostId == id);
        }

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="postName"></param>
        /// <returns></returns>
        public static bool ExistsPostName(string postName)
        {
            return Dao.ExistsPostName(postName);
        }

        /// <summary>
        ///     获取文章列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <param name="queryType"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T_Post> GetPostList(int pageSize, int pageIndex, out int recordCount, string keyword, int queryType, T_Post item)
        {
            return Dao.GetPostList(pageSize, pageIndex, out recordCount, keyword,queryType, item);
        }

        /// <summary>
        /// 获取最后一个文章
        /// </summary>
        /// <returns></returns>
        public static T_Post GetLastPost()
        {
            return Dao.GetLastPost();
        }
    }
}