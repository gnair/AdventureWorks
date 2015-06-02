using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksWebAPI.Models
{
    public class ProductsVM
    {
        public string Category;
        public IEnumerable<Product> Products;
    }
}
