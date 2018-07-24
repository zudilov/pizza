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
	public sealed class PizzaOrderEntry
	{
		private sealed class Configuration : EntityTypeConfiguration<PizzaOrderEntry>
		{
			public Configuration()
			{
				ToTable("PizzaOrderEntries");

				HasKey(x => x.Id);

				Property(x => x.Id)
					.HasColumnName("Id")
					.IsRequired()
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

				Property(x => x.PizzaId)
					.HasColumnName("PizzaId")
					.IsRequired();

				Property(x => x.Count)
					.HasColumnName("Count")
					.IsRequired();

				Property(x => x.Price)
					.HasColumnName("Price")
					.IsRequired();

				HasRequired(x => x.Pizza)
					.WithMany()
					.WillCascadeOnDelete(true);

				HasRequired(x => x.PizzaOrder)
					.WithMany()
					.WillCascadeOnDelete(true);
			}
		}

		public static EntityTypeConfiguration<PizzaOrderEntry> GetConfiguration()
		{
			return new Configuration();
		}

		public PizzaOrderEntry()
		{
		}

		[DataMember]
		public long Id { get; set; }

		[DataMember]
		public long PizzaId { get; set; }

		public Pizza Pizza { get; set; }

		[DataMember]
		public long PizzaOrderId { get; set; }

		public PizzaOrder PizzaOrder { get; set; }

		[DataMember]
		public int Count { get; set; }

		[DataMember]
		public int Price { get; set; }

		public override string ToString()
		{
			if(Pizza != null)
			{
				return Pizza.Name + " " + Count;
			}
			return base.ToString();
		}
	}
}
