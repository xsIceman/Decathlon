using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyeDecathlon.Models
{
	public class DecathlonDetails
	{
		public Decathlon Decathlon { get; set; }
		public List<DecathlonEvent> Events { get; set; }
	}

	public class DecathlonEvent
	{
		public int EventId { get; set; }
		public string Name { get; set; }
		public bool Included { get; set; }
	}
}
