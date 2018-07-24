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
	public partial class EditPizzaForm : Form
	{
		public EditPizzaForm()
		{
			InitializeComponent();

		}
		public string PizzaName
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}
		public int Price
		{
			get
			{
				return Convert.ToInt32(numericUpDown2.Value);
							}
			set
			{
				numericUpDown2.Value = value;
			}
		}

		private void EditPizzaForm_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
