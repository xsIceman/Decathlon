using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class EventResult
	{
		public string EventName { get; set; }
		public int EventId { get; set; }
		public List<Athlete> Athletes { get; set; }

	}
}