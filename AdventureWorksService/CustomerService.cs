using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace AdventureWorksService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	internal class CustomerService : ICustomerService, IDisposable
	{
		internal CustomerService()
		{
		}

        #region ICustomerService Members

        public List<Customer> GetCustomers()
		{
            return null;
		}

		#endregion


		#region IDisposable Members

		public void Dispose()
		{
			// No action required.
		}

		#endregion

	}
}
