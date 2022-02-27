using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Entities
{
    public class Store
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; } //= new List<Product>();
        public virtual IList<Employee> Staff { get; set; } //= new List<Employee>();
    }
}
