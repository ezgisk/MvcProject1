namespace MvcProject1.Models.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BookCount { get; set; } // Yazara ait kitap sayısı
    }
}
