using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AdventureWorksService
{
   class CustomerServiceHost : ServiceHost
   {
      // The error handlers for this service host.
      private List<IServiceBehavior> m_ErrorHandlers = new List<IServiceBehavior>();

      public CustomerServiceHost(Type serviceType)
          : base(serviceType)
      {
      }

      protected override void OnOpening()
      {
         foreach (IServiceBehavior behavior in m_ErrorHandlers)
         {
            Description.Behaviors.Add(behavior);
         }

         base.OnOpening();
      }

      protected override void OnClosing()
      {
         base.OnClosing();
      }
   }
}
