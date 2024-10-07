using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEdgePracticeExample.Models
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap() 
        {
            Table("Products");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
        }
    }
}