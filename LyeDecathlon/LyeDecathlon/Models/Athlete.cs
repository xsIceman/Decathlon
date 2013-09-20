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

		[Display(Name = "100 meter (sec)")]
		public double? Meter100 { get; set; }
		[Display(Name = "1500 meter (sec)")]
		public double? Meter1500 { get; set; }
		[Display(Name = "400 meter (sec)")]
		public double? Meter400 { get; set; }
		[Display(Name = "110  meter hekk (sec)")]
		public double? Hurdles110 { get; set; }
		[Display(Name = "Lengde (cm)")]
		public double? LongJump { get; set; }
		[Display(Name = "Kulestøt (meter)")]
		public double? ShotPut { get; set; }
		[Display(Name = "høyde (cm)")]
		public double? HighJump { get; set; }
		[Display(Name = "Diskos (meter)")]
		public double? DiscusThrow { get; set; }
		[Display(Name = "stavsprang (cm)")]
		public double? PoleVault { get; set; }
		[Display(Name = "Spyd (meter)")]
		public double? JavelinThrow { get; set; }

		[NotMapped]
		public double Result
		{
			get
			{
				return CalculateRes();
			}
		}

		private double CalculateRes()
		{
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

			var res = 0.0;
			if (Meter100.HasValue)
				res += DecResRun(Meter100.Value, 25.4347, 18.0, 1.81);
			if (LongJump.HasValue)
				res += DecResLength(LongJump.Value, 0.14354, 220, 1.4);
			if (ShotPut.HasValue)
				res += DecResLength(ShotPut.Value, 51.39, 1.5, 1.05);
			if (HighJump.HasValue)
				res += DecResLength(HighJump.Value, 0.8465, 75, 1.42);
			if (Meter400.HasValue)
				res += DecResRun(Meter400.Value, 1.53775, 82, 1.82);
			if (Hurdles110.HasValue)
				res += DecResRun(Hurdles110.Value, 5.74352, 28.5, 1.92);
			if (DiscusThrow.HasValue)
				res += DecResLength(DiscusThrow.Value, 12.91, 4, 1.1);
			if (PoleVault.HasValue)
				res += DecResLength(PoleVault.Value, 0.2797, 100, 1.35);
			if (JavelinThrow.HasValue)
				res += DecResLength(JavelinThrow.Value, 10.14, 7, 1.08);
			if (Meter1500.HasValue)
				res += DecResRun(Meter1500.Value, 0.03768, 480, 1.85);
			return res;
		}

		private double DecResRun(double res, double a, double b, double c)
		{
			return a * Math.Pow((b - res), c);
		}

		private double DecResLength(double res, double a, double b, double c)
		{
			return a * Math.Pow((res - b), c);
		}
	}
}