using Framework.DataStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace PizzaServer
{
	[ServiceContract]
	public interface IPizzaService
	{
		[OperationContract]
		[WebGet]
		PizzaOrder[] GetOrders();

		[OperationContract]
		[WebInvoke]
		void SetPizza(Pizza pizza);

		[OperationContract]
		[WebInvoke]
		void RemovePizza(Pizza pizza);

		[OperationContract]
		[WebInvoke]
		long SetOrder(PizzaOrder order);

		[OperationContract]
		[WebInvoke]
		void RemoveOrder(PizzaOrder order);

		[OperationContract]
		[WebGet]
		Pizza[] GetPizzas();
	}
}
