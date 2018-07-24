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
	public partial class MainForm : Form
	{
		public MainForm(IPizzaService pizzaService)
		{
			PizzaService = pizzaService;

			InitializeComponent();

			Font = SystemFonts.MessageBoxFont;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			UpdatePizzas();
		}

		private IPizzaService PizzaService { get; }

		private void button1_Click(object sender, EventArgs e)
		{
			if(listBox1.SelectedItem != null)
			{
				var selectedPizza = (Pizza)listBox1.SelectedItem;

				var addedPizzaEntry = listBox2.Items.OfType<PizzaOrderEntry>().FirstOrDefault(x => x.PizzaId == selectedPizza.Id);

				if(addedPizzaEntry != null)
				{
					listBox2.Items.Remove(addedPizzaEntry);
					addedPizzaEntry.Count = addedPizzaEntry.Count + Convert.ToInt32(numericUpDown1.Value);
					listBox2.Items.Add(addedPizzaEntry);
				}
				else
				{
					var pizzaEntry = new PizzaOrderEntry()
					{
						Count = Convert.ToInt32(numericUpDown1.Value),
						Price = selectedPizza.Price,
						Pizza = selectedPizza,
						PizzaId = selectedPizza.Id,
					};
					listBox2.Items.Add(pizzaEntry);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(listBox2.Items.Count > 0 && !string.IsNullOrWhiteSpace(textBox1.Text))
			{
				var pizzaEntries = listBox2.Items.OfType<PizzaOrderEntry>().ToList();

				var pizzaOrder = new PizzaOrder()
				{
					Address = textBox1.Text,
					Pizzas = pizzaEntries,
				};

				var id = PizzaService.SetOrder(pizzaOrder);
				MessageBox.Show (this, "Ваш заказ успешно оформлен. № заказа " + id, "Заказ", MessageBoxButtons.OK, MessageBoxIcon.Information);
				textBox1.Clear();
				listBox1.Items.Clear();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using(var form = new EditPizzaForm())
			{
				if(form.ShowDialog(this) == DialogResult.OK)
				{
					PizzaService.SetPizza(new Pizza()
					{
						Name = form.PizzaName,
						Price = form.Price,
					});
					UpdatePizzas();
				}
			}
		}

		private void UpdatePizzas()
		{
			listBox1.Items.Clear();
			foreach(var pizza in PizzaService.GetPizzas())
			{
				listBox1.Items.Add(pizza);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			if(listBox1.SelectedItem != null)
			{
				PizzaService.RemovePizza((Pizza)listBox1.SelectedItem);
				UpdatePizzas();
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			using(var form = new PizzaOrdersExplorer(PizzaService))
			{	
				form.ShowDialog(this);
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}
	}
}
