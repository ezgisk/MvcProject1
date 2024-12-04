﻿namespace MvcProject1.Models
{
    public class Book
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public string Genre { get; set; }
            public DateTime PublishDate { get; set; }
            public string ISBN { get; set; }
            public int CopiesAvailable { get; set; }

            // Navigation property to link with Author
            public Author Author { get; set; }
        }    
}
