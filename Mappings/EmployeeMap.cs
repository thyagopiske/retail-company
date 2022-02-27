using FluentNHibernate.Mapping;
using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(e => e.Id);
            Map(e => e.FirstName).Not.Nullable();
            Map(e => e.LastName).Not.Nullable();
            References(e => e.Store);
        }                        
    }
}
