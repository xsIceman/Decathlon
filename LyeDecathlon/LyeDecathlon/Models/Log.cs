using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyeDecathlon.Models
{
	public class Log
	{
		public int LogId { get; set; }

		public string AthleteName { get; set; }

		public string Event { get; set; }

		public double? Result { get; set; }

		public DateTime LogTime { get; set; }
	}
}
