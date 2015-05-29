using AutoMapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AdventureWorksService
{
    class CustomerServiceHost : ServiceHost
    {
        public CustomerServiceHost(Type serviceType)
            : base(serviceType)
        {
        }

        protected override void OnOpening()
        {
            base.OnOpening();

            // Create the Automapper mappings.
            Mapper.CreateMap<AdventureWorks.Model.Customer, Customer>();
        }

        protected override void OnClosing()
        {
            base.OnClosing();
        }
    }
}
