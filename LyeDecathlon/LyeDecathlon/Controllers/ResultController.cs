﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyeDecathlon.Models;

namespace LyeDecathlon.Controllers
{
	[Authorize]
	public class ResultController : Controller
	{
		private DecathlonContext db = new DecathlonContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Event(int eventId)
		{
			var eventRes = new EventResult();
			eventRes.Athletes = db.Athletes.ToList();
			eventRes.EventId = eventId;
			eventRes.EventName = GetName(eventId);
			return View(eventRes);
		}

		[HttpPost]
		public ActionResult SaveResult(int eventId, int athleteId, double? result)
		{
			var athlete = db.Athletes.Find(athleteId);
			if (athlete != null)
			{
				switch ((EventEnum)eventId)
				{
					case EventEnum.Meter100:
						athlete.Meter100 = result;
						break;
					case EventEnum.Meter1500:
						athlete.Meter400 = result;
						break;
					case EventEnum.Meter400:
						athlete.Meter400 = result;
						break;
					case EventEnum.Hurdles110:
						athlete.Meter400 = result;
						break;
					case EventEnum.LongJump:
						athlete.Meter400 = result;
						break;
					case EventEnum.ShotPut:
						athlete.Meter400 = result;
						break;
					case EventEnum.HighJump:
						athlete.Meter400 = result;
						break;
					case EventEnum.DiscusThrow:
						athlete.Meter400 = result;
						break;
					case EventEnum.PoleVault:
						athlete.Meter400 = result;
						break;
					case EventEnum.JavelinThrow:
						athlete.Meter400 = result;
						break;
					default:
						return Content("Could not find event");
				}
				db.SaveChanges();
				return Content("Saved");
			}
			return Content("Could not find Athlete");
		}

		private static string GetName(int eventId)
		{
			switch ((EventEnum)eventId)
			{
				case EventEnum.Meter100:
					return "100 meter";
				case EventEnum.Meter1500:
					return "1500 meter";
				case EventEnum.Meter400:
					return "400 meter";
				case EventEnum.Hurdles110:
					return "110 meter hinder";
				case EventEnum.LongJump:
					return "Lengde";
				case EventEnum.ShotPut:
					return "kule st;t";
				case EventEnum.HighJump:
					return "h;yde";
				case EventEnum.DiscusThrow:
					return "discus";
				case EventEnum.PoleVault:
					return "Stav sprang";
				case EventEnum.JavelinThrow:
					return "Spyd";
				default:
					return "Batman vs SuperMan";
			}
		}
	}
}
