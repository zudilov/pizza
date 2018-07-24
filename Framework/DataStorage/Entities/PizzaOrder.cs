using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataStorage.Entities
{
	[DataContract]
	public sealed class PizzaOrder
	{
		private sealed class Configuration : EntityTypeConfiguration<PizzaOrder>
		{
			public Configuration()
			{
				ToTable("PizzaOrders");

				HasKey(x => x.Id);

				Property(x => x.Id)
					.HasColumnName("Id")
					.IsRequired()
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

				Property(x => x.Address)
					.HasColumnName("Address")
					.IsRequired()
					.IsUnicode()
					.IsVariableLength()
					.IsMaxLength();

				HasMany(x => x.Pizzas)
					.WithOptional()
					.HasForeignKey(x => x.PizzaOrderId)
					.WillCascadeOnDelete(true);
			}
		}

		public static EntityTypeConfiguration<PizzaOrder> GetConfiguration()
		{
			return new Configuration();
		}

		public PizzaOrder()
		{
			Pizzas = new List<PizzaOrderEntry>();
		}

		[DataMember]
		public long Id { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public List<PizzaOrderEntry> Pizzas { get; set; }

		public override string ToString()
		{
			return Address + " номер заказа " + Id;
		}
	}
}
