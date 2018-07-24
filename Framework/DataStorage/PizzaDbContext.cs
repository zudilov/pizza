using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Framework.DataStorage.Entities;

namespace Framework.DataStorage
{
	public sealed class PizzaDbContext : DbContext
	{
		public PizzaDbContext(string connetionString)
			: base(connetionString)
		{
			
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var conf = modelBuilder.Configurations;
			conf.Add(Pizza.GetConfiguration());
			conf.Add(PizzaOrder.GetConfiguration());
			conf.Add(PizzaOrderEntry.GetConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
