using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class Decathlon
	{
		public int DecathlonId { get; set; }
		public string Name { get; set; }
		public ICollection<Event> Events  { get; set; }
		public ICollection<Athlete> Athletes { get; set; }
		public ICollection<EventResult> EventResults { get; set; }
	}
}