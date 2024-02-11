using System;
using System.Collections.Generic;

namespace BookCatalogAPI.Models
{
    public partial class BookAuthor
    {
        public int? FkBook { get; set; }
        public int? FkAuthor { get; set; }

        public virtual Author? FkAuthorNavigation { get; set; }
        public virtual Book? FkBookNavigation { get; set; }
    }
}
