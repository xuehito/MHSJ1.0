using System;
using System.Web.Mvc;
using MHSJ.Core.Service.Account;
using MHSJ.Core.Service.Admin;
using MHSJ.Core.Service.MyCenter;
using MHSJ.Entity;

namespace MHSJ.Web.Controllers
{
    public class PostController : BaseWebController
    {
        public int IsCollection { get; set; }
        public int AccountId;

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PostId(int id = -1)
        {
            int accountId = PageUtils.CurrentAccountId;

            T_Post postInfo = Biz_PostManager.biz_post.GetSinglePost(new T_Post {PostId = id});
            if (postInfo == null)
                return PromptView("/", "你访问的页面不存在");

            var model = new V_Post();
            model.ImageUrl = ViewBag.SiteUrl + postInfo.ImageUrl;
            model.Tword = (string.IsNullOrEmpty(postInfo.TWord) ? postInfo.Word : postInfo.TWord);
            model.FromName = postInfo.FromName;
            model.WriterName = postInfo.WriterName;
            model.PostId = postInfo.PostId;
            model.Browses = postInfo.Browses;

            bool result = Biz_CollectionManager.biz_collection.IsCollection(id, accountId);
            ViewBag.IsCollection = 0;
            if (result)
            {
                ViewBag.IsCollection = 1;
            }

            var da = Biz_PostManager.biz_post.UpdateBrowses(new T_Post { PostId = id, Browses = postInfo.Browses + 1 });
            if (da != 0)
            {
                model.Browses = model.Browses + 1;
            }

            return View(model);
        }

        /// <summary>
        /// 收藏作品
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="type"></param>
        /// <param name="postId"></param>
        /// <returns>state:[0:操作失败;1:成功;2:收藏失败;3:登录失败]</returns>
        [HttpPost]
        //filterContext.Result = new RedirectResult("/Account/Login", true);
        public JsonResult Collection(ActionExecutingContext filterContext,string type, int postId = -1)
        {
            if (!PageUtils.IsAccountLogin)
            {
                return Json(new
                {
                    state = "3",
                });
            }
            var result = UpdateState(type, postId);
           
            //if (result==1)
            //{
            //    if (type == "cancel")
            //    {
            //        return Json(new
            //        {
            //            state = result,
            //            type = "success",
            //            message = "取消成功"
            //        });
            //    }
            //    else
            //    {
            //        return Json(new
            //        {
            //            state = result,
            //            type = "success",
            //            message = "收藏成功"
            //        });
            //    }
            //}
            //else if (result == 2)
            //{
            //    return Json(new
            //    {
            //        state = result,
            //        type = "error",
            //        message = ""
            //    });
            //}

            return Json(new
            {
                state = result,
            });
        }

        /// <summary>
        /// 更新收藏状态
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateState(string type, int postId)
        {
            AccountId = PageUtils.CurrentAccountId;

            bool result = false;
            var state = 0;
            var item=new T_Collection();

            var integralInfo = Biz_IntegralManager.biz_integral.GetIntegral(Convert.ToInt32(AccountId));
            var number = Biz_CollectionManager.biz_collection.GetAccountCollectionNumber(new T_Collection() { AccountId = Convert.ToInt32(AccountId) });

            if (integralInfo.CollectionnNumber <= number && type=="collection") return 2;//判断是否超过最大收藏数

            bool isCollection = Biz_CollectionManager.biz_collection.IsCollection(postId, AccountId, state);
            if (!isCollection)//判断是否已收藏
            {
                item = new T_Collection
                {
                    AccountId = AccountId,
                    PostId = postId,
                    State = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                result = Biz_CollectionManager.biz_collection.CollectionPost(item);
            }
            if (result) return 1;
            
            var info = new T_Collection
            {
                CollectionId = Biz_CollectionManager.biz_collection.QueryId(postId, PageUtils.CurrentAccountId),
                UpdateDate = DateTime.Now
            };

            switch (type)
            {
                case "cancel":
                    info.State = 0;
                    break;
                case "collection":
                    info.State = 1;
                    break;
                default:
                    info.State = 1;
                    break;
            }

            if (Biz_CollectionManager.biz_collection.CancelCollection(info)) return 1;
            
            return 0;
        }
    }
}