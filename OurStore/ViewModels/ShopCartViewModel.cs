using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurStore.Model;

namespace OurStore.ViewModels
{
    public class ShopCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}