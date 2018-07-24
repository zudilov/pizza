using PizzaServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaClient
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			using(var cf = new ChannelFactory<IPizzaService>(new WebHttpBinding(), "http://localhost:8000"))
			{
				cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

				var channel = cf.CreateChannel();

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm(channel));
			}
		}
	}
}
