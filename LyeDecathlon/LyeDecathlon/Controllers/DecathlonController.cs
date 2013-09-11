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
	public class DecathlonController : Controller
	{
		private DecathlonContext db = new DecathlonContext();

		//
		// GET: /Decathlon/

		public ActionResult Index()
		{
			return View(db.Decathlons.ToList());
		}

		//
		// GET: /Decathlon/Details/5

		public ActionResult Details(int id = 0)
		{
			Decathlon decathlon = db.Decathlons.Include(d => d.Events).Where(l => l.DecathlonId == id).FirstOrDefault();
			if (decathlon == null)
			{
				return HttpNotFound();
			}

			var events = db.Events.Select(d => new DecathlonEvent() { EventId = d.EventId, Name = d.Name }).ToList();
			foreach (var e in decathlon.Events)
			{
				var ee = events.Where(t => t.EventId == e.EventId).FirstOrDefault();
				if (ee != null)
					ee.Included = true;
			}

			return View(new DecathlonDetails() { Decathlon = decathlon, Events = events });
		}

		//
		// GET: /Decathlon/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Decathlon/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Decathlon decathlon)
		{
			if (ModelState.IsValid)
			{
				db.Decathlons.Add(decathlon);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(decathlon);
		}

		//
		// GET: /Decathlon/Edit/5

		public ActionResult Edit(int id = 0)
		{
			Decathlon decathlon = db.Decathlons.Find(id);
			if (decathlon == null)
			{
				return HttpNotFound();
			}
			return View(decathlon);
		}

		//
		// POST: /Decathlon/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Decathlon decathlon)
		{
			if (ModelState.IsValid)
			{
				db.Entry(decathlon).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(decathlon);
		}

		//
		// GET: /Decathlon/Delete/5

		public ActionResult Delete(int id = 0)
		{
			Decathlon decathlon = db.Decathlons.Find(id);
			if (decathlon == null)
			{
				return HttpNotFound();
			}
			return View(decathlon);
		}

		//
		// POST: /Decathlon/Delete/5

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Decathlon decathlon = db.Decathlons.Find(id);
			db.Decathlons.Remove(decathlon);
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