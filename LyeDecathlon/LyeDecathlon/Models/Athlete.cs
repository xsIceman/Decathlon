using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class Athlete
	{
		public int AthleteId { get; set; }
		public string Name { get; set; }
		public ICollection<EventResult> Results { get; set; }
		public ICollection<Decathlon> Decathlons { get; set; }
	}
}