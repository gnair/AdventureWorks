using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AdventureWorksService
{
    [ServiceContract]
    interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetCustomers();
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public Nullable<int> PersonID { get; set; }
        [DataMember]
        public Nullable<int> StoreID { get; set; }
        [DataMember]
        public Nullable<int> TerritoryID { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public System.Guid rowguid { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
    }

}
