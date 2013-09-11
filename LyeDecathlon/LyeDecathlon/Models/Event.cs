using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class Event
	{
		public int EventId { get; set; }
		public string Name { get; set; }
		public string Unit { get; set; }
		public double A { get; set; }
		public double B { get; set; }
		public double C { get; set; }
	}
}