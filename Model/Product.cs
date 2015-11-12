using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurStore.Model
{
    [Bind(Exclude = "ProductId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(160)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 100000.00,
            ErrorMessage = "Price must be between 0.00 and 100000.00")]
        public decimal Price { get; set; }

        [DisplayName("Product Picture URL")]
        [StringLength(1024)]
        public String ProductPicUrl { get; set; }

        public virtual Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}