using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using Framework.DataStorage;
using Framework.DataStorage.Entities;

namespace PizzaServer
{
	public sealed class PizzaService : IPizzaService
	{
		public PizzaService()
		{
			Configuration = new SqlServerConnetionConfiguration();
		}

		public SqlServerConnetionConfiguration Configuration { get; }

		public PizzaOrder[] GetOrders()
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				var orders = context
					.Set<PizzaOrder>()
					.Include(x => x.Pizzas)
					.Include(x => x.Pizzas.Select(y => y.Pizza))
					.ToArray();

				return orders;
			}
		}

		public Pizza[] GetPizzas()
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				return context.Set<Pizza>().ToArray();
			}
		}

		public void RemoveOrder(PizzaOrder order)
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				var p = context.Set<PizzaOrder>().FirstOrDefault(x => x.Id == order.Id);
				if(p != null)
				{
					context.Set<PizzaOrder>().Remove(p);
					context.SaveChanges();
				}
			}
		}

		public void RemovePizza(Pizza pizza)
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				var p = context.Set<Pizza>().FirstOrDefault(x => x.Id == pizza.Id);
				if(p != null)
				{
					context.Set<Pizza>().Remove(p);
					context.SaveChanges();
				}
			}
		}

		public long SetOrder(PizzaOrder order)
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				context.Set<PizzaOrder>().Add(order);
				context.SaveChanges();
				return order.Id;
			}
		}

		public void SetPizza(Pizza pizza)
		{
			using(var context = new PizzaDbContext(Configuration.GetConnectionString()))
			{
				context.Set<Pizza>().Add(pizza);
				context.SaveChanges();
			}
		}
	}
}
