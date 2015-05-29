using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService
{
    public partial class AdventureWorkService : ServiceBase
    {
        private CustomerServiceHost customerServiceHost = null;

        public AdventureWorkService()
        {
            InitializeComponent();

            this.ServiceName = "AdventureWorks Service";
        }

        protected override void OnStart(string[] args)
        {
            customerServiceHost = new CustomerServiceHost(typeof(CustomerService));
            customerServiceHost.Open();
        }

        protected override void OnStop()
        {
            customerServiceHost.Close();
        }
    }
}
