using System;
using System.Collections.Generic;

namespace BookCatalogAPI.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
