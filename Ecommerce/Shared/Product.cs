using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Shared
{
   public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; } = "https://via.placeholder.com/300x300";

        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }


        public int CategoryId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }


        public Category Category { get; set; }
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

    }
}
