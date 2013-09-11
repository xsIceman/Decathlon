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
	public class EventController : Controller
	{
		private DecathlonContext db = new DecathlonContext();

		//
		// GET: /Event/

		public ActionResult Index()
		{
			return View(db.Events.ToList());
		}

		//
		// GET: /Event/Details/5

		public ActionResult Details(int id = 0)
		{
			Event eventvar = db.Events.Find(id);
			if (eventvar == null)
			{
				return HttpNotFound();
			}
			return View(eventvar);
		}

		//
		// GET: /Event/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Event/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Event eventvar)
		{
			if (ModelState.IsValid)
			{
				db.Events.Add(eventvar);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(eventvar);
		}

		//
		// GET: /Event/Edit/5

		public ActionResult Edit(int id = 0)
		{
			Event eventvar = db.Events.Find(id);
			if (eventvar == null)
			{
				return HttpNotFound();
			}
			return View(eventvar);
		}

		//
		// POST: /Event/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Event eventvar)
		{
			if (ModelState.IsValid)
			{
				db.Entry(eventvar).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(eventvar);
		}

		//
		// GET: /Event/Delete/5

		public ActionResult Delete(int id = 0)
		{
			Event eventvar = db.Events.Find(id);
			if (eventvar == null)
			{
				return HttpNotFound();
			}
			return View(eventvar);
		}

		//
		// POST: /Event/Delete/5

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Event eventvar = db.Events.Find(id);
			db.Events.Remove(eventvar);
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