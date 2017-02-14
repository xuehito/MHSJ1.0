using System;
using System.Web.Mvc;

namespace MHSJ.Web.Controllers
{
    public class HomeController : BaseWebController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Response.Redirect("~/index.aspx");

            return  View();
        }
    }
}
