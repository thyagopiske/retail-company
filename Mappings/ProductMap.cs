using FluentNHibernate.Mapping;
using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(p => p.Id);
            Map(p => p.Name);
            Map(p => p.Price);
            HasManyToMany(p => p.StoresStockedIn)
                .Cascade.All()
                .Inverse()
                .Table("StoreProduct");
        }  
    }      
}
