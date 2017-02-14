using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MHSJ.Web.Controllers
{
    public class SearchController : BaseWebController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchWord()
        {
            return View();
        }
    }
}