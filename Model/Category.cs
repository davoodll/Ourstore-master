using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurStore.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public List<Product> Products { get; set; }
    }
}