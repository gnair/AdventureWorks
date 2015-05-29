using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksService
{
    [RunInstaller(true)]
    public partial class AdventureWorkInstaller : System.Configuration.Install.Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;

        public AdventureWorkInstaller()
        {
            InitializeComponent();
            // 
            // ServiceProcessInstaller
            // 
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // ServiceInstaller
            // 
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.serviceInstaller1.ServiceName = "AdventureWorks Service";
            this.serviceInstaller1.DisplayName = "AdventureWorks Service";
            this.serviceInstaller1.Description = "AdventureWorks Service";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Manual;

            // Add the installer instances
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
                this.serviceProcessInstaller1, this.serviceInstaller1});
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}
