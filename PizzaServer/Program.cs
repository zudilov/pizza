using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

using Framework.DataStorage;
using Framework.DataStorage.Entities;

namespace PizzaServer
{
	class Program
	{
		static void Main(string[] args)
		{
			var conf = new SqlServerConnetionConfiguration();
			var cs = conf.GetConnectionString();
			using(var context = new PizzaDbContext(cs))
			{
				//context.Database.Delete();
				context.Database.CreateIfNotExists();

				var host = new WebServiceHost(typeof(PizzaService), new Uri("http://localhost:8000/"));
				var entryPoint = host.AddServiceEndpoint(typeof(IPizzaService), new WebHttpBinding(), "");

				host.Open();

				Console.ReadKey();

				host.Close();
			}
		}
	}
}
