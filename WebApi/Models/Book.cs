using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public int? PublishedYear { get; set; }

    public string? Isbn { get; set; }

    public decimal? Price { get; set; }
}
