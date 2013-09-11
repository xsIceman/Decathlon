using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class EventResult
	{
		public Decathlon Decathlon { get; set; }
		public int EventResultId { get; set; }
		public Event Event { get; set; }
		public double Result { get; set; }
		public double Score { get; set; }
	}
}