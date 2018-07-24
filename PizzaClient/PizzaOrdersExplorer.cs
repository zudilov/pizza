using Framework.DataStorage.Entities;
using PizzaServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaClient
{
	public partial class PizzaOrdersExplorer : Form
	{
		public IPizzaService PizzaService { get; }

		public PizzaOrdersExplorer(IPizzaService pizzaService)
		{
			InitializeComponent();
			PizzaService = pizzaService;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			UpdateData();
		}

		private void UpdateData()
		{
			var orders = PizzaService.GetOrders();
			var pizzas = PizzaService.GetPizzas();
			foreach(var order in orders)
			{
				foreach(var pizza in order.Pizzas)
				{
					pizza.Pizza = pizzas.FirstOrDefault(x => x.Id == pizza.PizzaId);
				}
			}

			listBox1.Items.Clear();
			foreach(var pizzaOrder in orders)
			{
				listBox1.Items.Add(pizzaOrder);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(listBox1.SelectedItem != null)
			{
				var pizzaEntries = ((PizzaOrder)listBox1.SelectedItem).Pizzas;
				listBox2.Items.Clear();
				foreach(var pizza in pizzaEntries)
				{
					listBox2.Items.Add(pizza);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(listBox1.SelectedItem != null)
			{
				PizzaService.RemoveOrder((PizzaOrder)listBox1.SelectedItem);
				listBox1.Items.Remove(listBox1.SelectedItem);
				listBox2.Items.Clear();
			}
		}
	}
}
