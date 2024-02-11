using System;
using System.Collections.Generic;

namespace BookCatalogAPI.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Synopsis { get; set; }
        public DateOnly? PublishDate { get; set; }
        public string? Cover { get; set; }
        public ushort? NumPages { get; set; }
        public string? Isbn { get; set; }
        public int? FkPublisher { get; set; }

        public virtual Publisher? FkPublisherNavigation { get; set; }
    }
}
