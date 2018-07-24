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
	public sealed class Pizza
	{
		private sealed class Configuration : EntityTypeConfiguration<Pizza>
		{
			public Configuration()
			{
				ToTable("Pizzas");

				HasKey(x => x.Id);

				Property(x => x.Id)
					.HasColumnName("Id")
					.IsRequired()
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

				Property(x => x.Name)
					.HasColumnName("Name")
					.IsRequired()
					.IsUnicode()
					.IsVariableLength()
					.IsMaxLength();

				Property(x => x.Price)
					.HasColumnName("Price")
					.IsRequired();
			}
		}

		public static EntityTypeConfiguration<Pizza> GetConfiguration()
		{
			return new Configuration();
		}

		public Pizza()
		{
		}

		[DataMember]
		public long Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Price { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
