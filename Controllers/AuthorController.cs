using Microsoft.AspNetCore.Mvc;
using MvcProject1.Models;
using MvcProject1.Models.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;

public class AuthorController : Controller
{
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
        var viewModel = authors.Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FullName = $"{a.FirstName} {a.LastName}",
            DateOfBirth = a.DateOfBirth
        }).ToList();

        return View(viewModel);
    }

    public IActionResult Details(int id)
    {
        var author = authors.FirstOrDefault(a => a.Id == id);
        return View(author);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Author author)
    {
        // Yeni yazarı ekle
        authors.Add(author);

        // Yazarlar listesine yönlendir
        return RedirectToAction("List");
    }


    public IActionResult Edit(int id)
    {
        // Yazar verisini al
        var author = authors.FirstOrDefault(a => a.Id == id);
        if (author == null)
        {
            return NotFound(); // Yazar bulunamazsa 404 döndür
        }

        return View(author); // Yazar verisi ile Edit sayfasını döndür
    }


    [HttpPost]
    public IActionResult Edit(Author author)
    {
        // Geçerli yazarı bul
        var existingAuthor = authors.FirstOrDefault(a => a.Id == author.Id);
        if (existingAuthor == null)
        {
            return NotFound(); // Yazar bulunamazsa 404 döndür
        }

        // Yazar bilgilerini güncelle
        existingAuthor.FirstName = author.FirstName;
        existingAuthor.LastName = author.LastName;
        existingAuthor.DateOfBirth = author.DateOfBirth;

        // Yazarlar listesine geri kaydet
        return RedirectToAction("List"); // Yazarlar listesine yönlendir
    }


    public IActionResult Delete(int id)
    {
        var author = authors.FirstOrDefault(a => a.Id == id);
        if (author == null)
        {
            return NotFound(); // Yazar bulunamazsa 404 döndür
        }

        return View(author); // Yazar verisi ile Delete sayfasını döndür
    }

    // Post: Author/Delete/5
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var author = authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            authors.Remove(author); // Yazar listeden silinir
        }

        return RedirectToAction("List"); // Yazarlar listesine yönlendir
    }

}
