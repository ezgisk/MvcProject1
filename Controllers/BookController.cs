using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Models;
using MvcProject1.Models.ViewModels;

public class BookController : Controller
{
    private static List<Book> books = new List<Book>
{
    new Book { Id = 1, Title = "C Sharp Basics", AuthorId = 1, Genre = "Programming", PublishDate = new DateTime(2022, 6, 15), ISBN = "123456", CopiesAvailable = 10 },
    new Book { Id = 2, Title = "ASP.NET Core Guide", AuthorId = 2, Genre = "Programming", PublishDate = new DateTime(2021, 10, 20), ISBN = "987654", CopiesAvailable = 5 },
    new Book { Id = 3, Title = "JavaScript Fundamentals", AuthorId = 3, Genre = "Programming", PublishDate = new DateTime(2020, 3, 10), ISBN = "234567", CopiesAvailable = 7 },
    new Book { Id = 4, Title = "HTML & CSS Essentials", AuthorId = 4, Genre = "Web Development", PublishDate = new DateTime(2021, 5, 18), ISBN = "345678", CopiesAvailable = 4 },
    new Book { Id = 5, Title = "React for Beginners", AuthorId = 5, Genre = "Web Development", PublishDate = new DateTime(2022, 9, 9), ISBN = "456789", CopiesAvailable = 3 },
    new Book { Id = 6, Title = "Node.js in Action", AuthorId = 6, Genre = "Programming", PublishDate = new DateTime(2021, 11, 25), ISBN = "567890", CopiesAvailable = 8 },
    new Book { Id = 7, Title = "Design Patterns Explained", AuthorId = 7, Genre = "Software Engineering", PublishDate = new DateTime(2019, 4, 2), ISBN = "678901", CopiesAvailable = 6 },
    new Book { Id = 8, Title = "Learning SQL", AuthorId = 8, Genre = "Database", PublishDate = new DateTime(2020, 12, 15), ISBN = "789012", CopiesAvailable = 9 },
    new Book { Id = 9, Title = "Building RESTful APIs", AuthorId = 9, Genre = "Web Development", PublishDate = new DateTime(2021, 1, 10), ISBN = "890123", CopiesAvailable = 5 },
    new Book { Id = 10, Title = "Angular Basics", AuthorId = 10, Genre = "Web Development", PublishDate = new DateTime(2022, 2, 25), ISBN = "901234", CopiesAvailable = 12 },
    new Book { Id = 11, Title = "Mastering Python", AuthorId = 11, Genre = "Programming", PublishDate = new DateTime(2021, 7, 30), ISBN = "112233", CopiesAvailable = 6 },
    new Book { Id = 12, Title = "Data Structures and Algorithms", AuthorId = 12, Genre = "Computer Science", PublishDate = new DateTime(2020, 8, 18), ISBN = "223344", CopiesAvailable = 10 },
    new Book { Id = 13, Title = "Java for Beginners", AuthorId = 13, Genre = "Programming", PublishDate = new DateTime(2019, 3, 12), ISBN = "334455", CopiesAvailable = 4 },
    new Book { Id = 14, Title = "Machine Learning 101", AuthorId = 14, Genre = "Artificial Intelligence", PublishDate = new DateTime(2022, 5, 5), ISBN = "445566", CopiesAvailable = 7 },
    new Book { Id = 15, Title = "Deep Learning with Python", AuthorId = 15, Genre = "Artificial Intelligence", PublishDate = new DateTime(2021, 6, 8), ISBN = "556677", CopiesAvailable = 3 },
    new Book { Id = 16, Title = "Docker Essentials", AuthorId = 16, Genre = "DevOps", PublishDate = new DateTime(2020, 9, 13), ISBN = "667788", CopiesAvailable = 9 },
    new Book { Id = 17, Title = "Kubernetes for Beginners", AuthorId = 17, Genre = "DevOps", PublishDate = new DateTime(2021, 4, 10), ISBN = "778899", CopiesAvailable = 6 },
    new Book { Id = 18, Title = "Cloud Computing Basics", AuthorId = 18, Genre = "Cloud", PublishDate = new DateTime(2022, 7, 19), ISBN = "889900", CopiesAvailable = 8 },
    new Book { Id = 19, Title = "Introduction to Blockchain", AuthorId = 19, Genre = "Blockchain", PublishDate = new DateTime(2020, 11, 2), ISBN = "990011", CopiesAvailable = 5 },
    new Book { Id = 20, Title = "Cybersecurity Fundamentals", AuthorId = 20, Genre = "Security", PublishDate = new DateTime(2021, 10, 5), ISBN = "101112", CopiesAvailable = 12 }
};


    private static List<Author> authors = new List<Author>
{
    new Author { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 3, 10) },
    new Author { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 7, 25) },
    new Author { Id = 3, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1982, 4, 15) },
    new Author { Id = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1978, 8, 30) },
    new Author { Id = 5, FirstName = "Charlie", LastName = "Davis", DateOfBirth = new DateTime(1992, 1, 11) },
    new Author { Id = 6, FirstName = "David", LastName = "Miller", DateOfBirth = new DateTime(1987, 5, 22) },
    new Author { Id = 7, FirstName = "Emma", LastName = "Wilson", DateOfBirth = new DateTime(1995, 12, 5) },
    new Author { Id = 8, FirstName = "Frank", LastName = "Moore", DateOfBirth = new DateTime(1980, 2, 17) },
    new Author { Id = 9, FirstName = "Grace", LastName = "Taylor", DateOfBirth = new DateTime(1991, 10, 9) },
    new Author { Id = 10, FirstName = "Henry", LastName = "Anderson", DateOfBirth = new DateTime(1983, 7, 14) },
    new Author { Id = 11, FirstName = "Ivy", LastName = "Thomas", DateOfBirth = new DateTime(1994, 9, 18) },
    new Author { Id = 12, FirstName = "Jack", LastName = "Jackson", DateOfBirth = new DateTime(1989, 6, 25) },
    new Author { Id = 13, FirstName = "Kathy", LastName = "White", DateOfBirth = new DateTime(1996, 4, 2) },
    new Author { Id = 14, FirstName = "Louis", LastName = "Harris", DateOfBirth = new DateTime(1984, 11, 20) },
    new Author { Id = 15, FirstName = "Mona", LastName = "Martin", DateOfBirth = new DateTime(1981, 12, 1) },
    new Author { Id = 16, FirstName = "Nathan", LastName = "Garcia", DateOfBirth = new DateTime(1993, 3, 25) },
    new Author { Id = 17, FirstName = "Olivia", LastName = "Martinez", DateOfBirth = new DateTime(1990, 5, 12) },
    new Author { Id = 18, FirstName = "Paul", LastName = "Rodriguez", DateOfBirth = new DateTime(1988, 8, 7) },
    new Author { Id = 19, FirstName = "Quincy", LastName = "Lee", DateOfBirth = new DateTime(1986, 10, 3) },
    new Author { Id = 20, FirstName = "Rachel", LastName = "Perez", DateOfBirth = new DateTime(1992, 2, 15) }
};


    public IActionResult List()
    {
        var viewModel = books.Select(b => new BookViewModel
        {
            Id = b.Id,
            Title = b.Title,
            AuthorFullName = $"{authors.FirstOrDefault(a => a.Id == b.AuthorId)?.FirstName} {authors.FirstOrDefault(a => a.Id == b.AuthorId)?.LastName}",
            Genre = b.Genre,
            PublishDate = b.PublishDate,
            ISBN = b.ISBN,
            CopiesAvailable = b.CopiesAvailable
        }).ToList();

        return View(viewModel);
    }

    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        var author = authors.FirstOrDefault(a => a.Id == book?.AuthorId);

        var viewModel = new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            AuthorFullName = $"{author?.FirstName} {author?.LastName}",
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            ISBN = book.ISBN,
            CopiesAvailable = book.CopiesAvailable
        };

        return View(viewModel);
    }

    public IActionResult Create()
    {
        // Yazarlar listesini oluşturuyoruz
        var authorsList = authors.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),  // Yazarın Id'si
            Text = $"{a.FirstName} {a.LastName}"  // Yazarın tam adı
        }).ToList();

        // View'a yazarlar listesini gönderiyoruz
        ViewBag.Authors = authorsList;

        return View();
    }


    [HttpPost]
    public IActionResult Create(Book book)
    {
        books.Add(book);
        return RedirectToAction("List");
    }

    public IActionResult Edit(int id)
    {
        // Kitap verisini al
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // Kitap bulunamazsa 404 döndür
        }

        // Yazarları ViewBag ile gönder (Yazarlar listesi)
        ViewBag.Authors = authors.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),
            Text = $"{a.FirstName} {a.LastName}",
            Selected = a.Id == book.AuthorId // Eğer yazar mevcut kitaba aitse seçili yap
        }).ToList();

        // Kitap modelini View'a gönder
        return View(book);
    }




    [HttpPost]
    public IActionResult Edit(Book book)
    {
        // Geçerli kitabı bul
        var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook == null)
        {
            return NotFound(); // Kitap bulunamazsa 404 döndür
        }

        // Kitap bilgilerini güncelle
        existingBook.Title = book.Title;
        existingBook.AuthorId = book.AuthorId; // Yazar ID'sini güncelle
        existingBook.Genre = book.Genre;
        existingBook.PublishDate = book.PublishDate;
        existingBook.ISBN = book.ISBN;
        existingBook.CopiesAvailable = book.CopiesAvailable;

        // Kitapları listeye geri kaydet
        return RedirectToAction("List");
    }


    // Delete metodunda, silinecek kitabın bilgilerini gösteriyoruz
    public IActionResult Delete(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book); // Kitap bilgisini Delete view'ine göndereceğiz
    }

    // DeleteConfirmed metodunda, kitabı listeden siliyoruz
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book); // Kitabı listeden siliyoruz
        }

        return RedirectToAction("List"); // Listeye geri dönüyoruz
    }

}
