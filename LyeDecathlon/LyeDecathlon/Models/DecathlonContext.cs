 ﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LyeDecathlon.Models
{
	public class DecathlonContext : DbContext
	{
		public DecathlonContext()
			: base("LyeDecathlon")
		{

		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Athlete> Athletes { get; set; }
		public DbSet<Log> Logs { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
