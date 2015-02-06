using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdvocateSearch.API_Operations;

namespace WebAdvocateSearch.Controllers
{
    public class SearchController : Controller
    {
        TwitterOperation TwitterObject = new TwitterOperation();
        //
        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getdata(string serachKey, string provider)
        {

            if (serachKey != "" && provider == "twitter")
            {
                return PartialView("_Twitter", TwitterObject.GetTweets(serachKey));
            }
            return PartialView();
        }
	}
}