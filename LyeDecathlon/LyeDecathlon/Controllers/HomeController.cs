using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyeDecathlon.Models;

namespace LyeDecathlon.Controllers
{
	public class HomeController : Controller
	{
		private DecathlonContext db = new DecathlonContext();

		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("Overview");
			ViewBag.Title = "22. Sep Lye Friidrett";
			return View();
		}

		[Authorize]
		public ActionResult Overview()
		{
			var athletes = db.Athletes.ToList();
			var orderedList = athletes.OrderByDescending(x => x.Result);
			return View(orderedList);
		}

		[Authorize]
		public ActionResult Result()
		{
			var athletes = db.Athletes.ToList();
			var orderedList = athletes.OrderByDescending(x => x.Result);
			return View(orderedList);
		}

	}
}
