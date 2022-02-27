using FluentNHibernate.Mapping;
using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(s => s.Id);
            Map(s => s.Name);
            HasMany(s => s.Staff)
                .Inverse()
                .Cascade.All();
            HasManyToMany(s => s.Products)
                .Cascade.All()
                .Table("StoreProduct");
        }
    }
}
