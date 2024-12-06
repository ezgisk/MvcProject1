using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Models;
using MvcProject1.Models.ViewModels;

public class BookController : Controller
{
    public static List<Book> books = new List<Book>
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

    public IActionResult List()
    {
        var bookViewModels = books.Select(book => new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            ISBN = book.ISBN,
            CopiesAvailable = book.CopiesAvailable,
            AuthorFullName = AuthorController.authors
                .FirstOrDefault(author => author.Id == book.AuthorId)?.FirstName + " " +
                               AuthorController.authors
                .FirstOrDefault(author => author.Id == book.AuthorId)?.LastName
        }).ToList();

        return View(bookViewModels);
    }

    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // Eğer kitap bulunamazsa 404 döner
        }

        var author = AuthorController.authors.FirstOrDefault(a => a.Id == book.AuthorId);
        var bookViewModel = new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            ISBN = book.ISBN,
            CopiesAvailable = book.CopiesAvailable,
            AuthorFullName = author != null ? $"{author.FirstName} {author.LastName}" : "Bilinmiyor"
        };

        return View(bookViewModel);
    }

    public IActionResult Create()
    {
        // Yazar listesini ViewBag ile gönder
        ViewBag.Authors = AuthorController.authors.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),
            Text = $"{a.FirstName} {a.LastName}"
        }).ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (books.Any())
            book.Id = books.Max(b => b.Id) + 1; // Yeni kitabın ID'sini oluştur
        else
            book.Id = 1;

        books.Add(book); // Kitabı listeye ekle
        return RedirectToAction("List");
    }

    public IActionResult Edit(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound(); // Kitap bulunamazsa 404 döner
        }

        // Yazar listesini ViewBag ile gönder
        ViewBag.Authors = AuthorController.authors.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),
            Text = $"{a.FirstName} {a.LastName}",
            Selected = a.Id == book.AuthorId // Kitaba atanmış yazar seçili olacak
        }).ToList();

        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook == null)
        {
            return NotFound(); // Kitap bulunamazsa 404 döner
        }

        // Kitap bilgilerini güncelle
        existingBook.Title = book.Title;
        existingBook.AuthorId = book.AuthorId;
        existingBook.Genre = book.Genre;
        existingBook.PublishDate = book.PublishDate;
        existingBook.ISBN = book.ISBN;
        existingBook.CopiesAvailable = book.CopiesAvailable;

        return RedirectToAction("List"); // Kitap listesine yönlendir
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
