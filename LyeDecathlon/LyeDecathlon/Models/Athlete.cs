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

		public double? Meter100 { get; set; }
		public double? Meter1500 { get; set; }
		public double? Meter400 { get; set; }
		public double? Hurdles110 { get; set; }
		public double? LongJump { get; set; }
		public double? ShotPut { get; set; }
		public double? HighJump { get; set; }
		public double? DiscusThrow { get; set; }
		public double? PoleVault { get; set; }
		public double? JavelinThrow { get; set; }


		//100 m					25.4347	18			1.81
		//Long jump				0.14354	220		1.4
		//Shot put				51.39		1.5		1.05
		//High jump				0.8465	75			1.42
		//400 m					1.53775	82			1.81
		//110 m hurdles		5.74352	28.5		1.92
		//Discus throw			12.91		4			1.1
		//Pole vault			0.2797	100		1.35
		//Javelin throw		10.14		7			1.08
		//1500 m					0.03768	480		1.85
	}
}