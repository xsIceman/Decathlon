using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyeDecathlon.Models;

namespace LyeDecathlon.Controllers
{
	[Authorize]
	public class AthleteController : Controller
	{
		private DecathlonContext db = new DecathlonContext();

		//
		// GET: /Default1/

		public ActionResult Index()
		{
			return View(db.Athletes.ToList());
		}

		//
		// GET: /Default1/Details/5

		public ActionResult Details(int id = 0)
		{
			Athlete athlete = db.Athletes.Find(id);
			if (athlete == null)
			{
				return HttpNotFound();
			}
			return View(athlete);
		}

		

		//
		// GET: /Default1/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Default1/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Athlete athlete)
		{
			if (ModelState.IsValid)
			{
				db.Athletes.Add(athlete);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(athlete);
		}

		//
		// GET: /Default1/Edit/5

		public ActionResult Edit(int id = 0)
		{
			Athlete athlete = db.Athletes.Find(id);
			if (athlete == null)
			{
				return HttpNotFound();
			}
			return View(athlete);
		}

		//
		// POST: /Default1/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Athlete athlete)
		{
			if (ModelState.IsValid)
			{
				db.Entry(athlete).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(athlete);
		}

		//
		// GET: /Default1/Delete/5

		public ActionResult Delete(int id = 0)
		{
			Athlete athlete = db.Athletes.Find(id);
			if (athlete == null)
			{
				return HttpNotFound();
			}
			return View(athlete);
		}

		//
		// POST: /Default1/Delete/5

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Athlete athlete = db.Athletes.Find(id);
			db.Athletes.Remove(athlete);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}