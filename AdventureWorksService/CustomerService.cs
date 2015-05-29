using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;




namespace AdventureWorksService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	internal class CustomerService : ICustomerService, IDisposable
	{
        private AdventureWorks.Model.AdventureWorks2014Entities db = new AdventureWorks.Model.AdventureWorks2014Entities();
        
        internal CustomerService()
		{
		}


        #region ICustomerService Members

        public List<Customer> GetCustomers()
        {
            var customers = db.Customers.Include(c => c.Person).Include(c => c.SalesTerritory).Include(c => c.Store);
            return Mapper.Map<List<Customer>>(customers.Take(100).ToList());
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
