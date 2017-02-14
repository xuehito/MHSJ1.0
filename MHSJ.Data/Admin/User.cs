using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MHSJ.Data.Common;
using MHSJ.Entity;

namespace MHSJ.Data.Admin
{
    public class User
    {
        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="_userinfo"></param>
        /// <returns></returns>
        public int InsertUser(UserInfo _userinfo)
        {
            return 0;
        }

//            string cmdText = @" insert into [loachs_users](
//                                [Type],[UserName],[Name],[Password],[Email],[SiteUrl],[AvatarUrl],[Description],[displayorder],[Status],[PostCount],[CommentCount],[CreateDate])
//                                values (
//                                @Type,@UserName,@Name,@Password,@Email,@SiteUrl,@AvatarUrl,@Description,@Displayorder,@Status, @PostCount,@CommentCount,@CreateDate )";
//            SqlParameter[] prams = { 
//                                        new SqlParameter("@Type", OleDbType.Integer,4, _userinfo.Type),
//                                        new SqlParameter("@UserName", OleDbType.VarWChar,50, _userinfo.UserName),
//                                        new SqlParameter("@Name", OleDbType.VarWChar,50, _userinfo.Name),
//                                        new SqlParameter("@Password", OleDbType.VarWChar,50, _userinfo.Password),
//                                        new SqlParameter("@Email", OleDbType.VarWChar,50, _userinfo.Email),
//                                        new SqlParameter("@SiteUrl", OleDbType.VarWChar,255, _userinfo.SiteUrl),
//                                        new SqlParameter("@AvatarUrl", OleDbType.VarWChar,255, _userinfo.AvatarUrl),
//                                        new SqlParameter("@Displayorder", OleDbType.VarWChar,255, _userinfo.Description),
//                                        new SqlParameter("@Status", OleDbType.Integer,4, _userinfo.Displayorder),
//                                        new SqlParameter("@Status", OleDbType.Integer,4, _userinfo.Status),                           
//                                        new SqlParameter("@PostCount", OleDbType.Integer,4, _userinfo.PostCount),
//                                        new SqlParameter("@CommentCount", OleDbType.Integer,4, _userinfo.CommentCount),
//                                        new SqlParameter("@CreateDate", OleDbType.Date,8, _userinfo.CreateDate),

//                                    };
//            int r = DbHelperSQL.ExecuteNonQuery(CommandType.Text, cmdText, prams);
//            if (r > 0)
//            {
//                return Convert.ToInt32(DbHelperSQL.ExecuteScalar("select top 1 [UserId] from [loachs_users]  order by [UserId] desc"));
//            }
//            return 0;
//        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="_userinfo"></param>
        /// <returns></returns>
        public int UpdateUser(UserInfo _userinfo)
        {
            return 0;
        }

//            string cmdText = @"update [loachs_users] set
//                                [Type]=@Type,
//                                [UserName]=@UserName,
//                                [Name]=@Name,
//                                [Password]=@Password,
//                                [Email]=@Email,
//                                [SiteUrl]=@SiteUrl,
//                                [AvatarUrl]=@AvatarUrl,
//                                [Description]=@Description,
//                                [Displayorder]=@Displayorder,
//                                [Status]=@Status,
//                                [PostCount]=@PostCount,
//                                [CommentCount]=@CommentCount,
//                                [CreateDate]=@CreateDate
//                                where UserId=@UserId";
//            OleDbParameter[] prams = { 
//                                        DbHelperSQL.MakeInParam("@Type", OleDbType.Integer,4, _userinfo.Type),
//                                        DbHelperSQL.MakeInParam("@UserName", OleDbType.VarWChar,50, _userinfo.UserName),
//                                        DbHelperSQL.MakeInParam("@Name", OleDbType.VarWChar,50, _userinfo.Name),
//                                        DbHelperSQL.MakeInParam("@Password", OleDbType.VarWChar,50, _userinfo.Password),
//                                        DbHelperSQL.MakeInParam("@Email", OleDbType.VarWChar,50, _userinfo.Email),
//                                        DbHelperSQL.MakeInParam("@SiteUrl", OleDbType.VarWChar,255, _userinfo.SiteUrl),
//                                        DbHelperSQL.MakeInParam("@AvatarUrl", OleDbType.VarWChar,255, _userinfo.AvatarUrl),
//                                        DbHelperSQL.MakeInParam("@Description", OleDbType.VarWChar,255, _userinfo.Description),
//                                        DbHelperSQL.MakeInParam("@Displayorder", OleDbType.VarWChar,255, _userinfo.Displayorder),
//                                        DbHelperSQL.MakeInParam("@Status", OleDbType.Integer,4, _userinfo.Status),                           
//                                        DbHelperSQL.MakeInParam("@PostCount", OleDbType.Integer,4, _userinfo.PostCount),
//                                        DbHelperSQL.MakeInParam("@CommentCount", OleDbType.Integer,4, _userinfo.CommentCount),
//                                        DbHelperSQL.MakeInParam("@CreateDate", OleDbType.Date,8, _userinfo.CreateDate),
//                                        DbHelperSQL.MakeInParam("@UserId", OleDbType.Integer,4, _userinfo.UserId),
//                                    };
//            return DbHelperSQL.ExecuteNonQuery(CommandType.Text, cmdText, prams);
//        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteUser(int userid)
        {
            return 0;
        }

//            string cmdText = "delete from [loachs_users] where [userid] = @userid";
//            OleDbParameter[] prams = { 
//                                        DbHelperSQL.MakeInParam("@userid",OleDbType.Integer,4,userid)
//                                    };
//            return DbHelperSQL.ExecuteNonQuery(CommandType.Text, cmdText, prams);
//        }


        ///// <summary>
        ///// 获取实体
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public UserInfo GetUser(string userName, string password)
        //{
        //    string cmdText = "select * from [loachs_users] where [userName] = @userName and [Password]=@password";
        //    OleDbParameter[] prams = { 
        //                        DbHelperSQL.MakeInParam("@userName",OleDbType.VarWChar,50,userName),
        //                        DbHelperSQL.MakeInParam("@password",OleDbType.VarWChar,50,password),
        //                    };
        //    List<UserInfo> list = DataReaderToUserList(DbHelperSQL.ExecuteReader(CommandType.Text, cmdText, prams));
        //    if (list.Count > 0)
        //    {
        //        return list[0];
        //    }
        //    return null;

        //}


        /// <summary>
        ///     获取全部
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserList()
        {
            string cmdText = "select * from [T_UserInfo]  order by [Createdate] asc";
            return DataReaderToUserList(DbHelperSQL.ExecuteReader(cmdText));
        }


        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ExistsUserName(string userName)
        {
            string cmdText = "select count(1) from [loachs_users] where [userName] = @userName ";
            SqlParameter[] prams =
            {
                new SqlParameter("@userName", SqlDbType.VarChar, 50, userName)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(cmdText, prams)) > 0;
        }

        /// <summary>
        ///     数据转换
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        private List<UserInfo> DataReaderToUserList(SqlDataReader read)
        {
            var list = new List<UserInfo>();
            while (read.Read())
            {
                var userinfo = new UserInfo();
                userinfo.UserId = Convert.ToInt32(read["UserId"]);
                userinfo.Type = Convert.ToInt32(read["Type"]);
                userinfo.UserName = Convert.ToString(read["UserName"]);
                userinfo.Name = Convert.ToString(read["Name"]);
                userinfo.Password = Convert.ToString(read["Password"]);
                userinfo.Email = Convert.ToString(read["Email"]);
                userinfo.Status = Convert.ToInt32(read["Status"]);
                userinfo.CreateDate = Convert.ToDateTime(read["CreateDate"]);

                list.Add(userinfo);
            }
            read.Close();
            return list;
        }
    }
}