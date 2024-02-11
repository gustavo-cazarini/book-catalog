using System;
using System.Collections.Generic;

namespace BookCatalogAPI.Models
{
    public partial class BookCategory
    {
        public int? FkBook { get; set; }
        public int? FkCategory { get; set; }

        public virtual Book? FkBookNavigation { get; set; }
        public virtual Category? FkCategoryNavigation { get; set; }
    }
}
