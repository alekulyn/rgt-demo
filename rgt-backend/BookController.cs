using Microsoft.AspNetCore.Mvc;

namespace BookApp;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    IBookFactory _factory;

    BookController()
    {
        _factory = new BookFactory();
    }

    [HttpGet]
    public Task<BookModel> GetBook(int id)
    {
        var book = _factory.GetBooks(id);

        return Task.FromResult(book.FirstOrDefault());
    }

    [HttpGet]
    public IEnumerable<BookModel> GetBooks()
    {
        var books = _factory.GetBooks();

        return books;
    }

    [HttpPut]
    public ActionResult<int> UpdateBook(EditBookRequest request)
    {
        _factory.ModifyBook(request.id, request.book);
        return null;
    }

    [HttpPost]
    public ActionResult<int> AddBook(BookModel book)
    {
        _factory.AddBook(book);
        return null;
    }

    [HttpDelete]
    public ActionResult<IEnumerable<BookModel>> DeleteBook(int bookId)
    {
        _factory.DeleteBook(bookId);
        return null;
    }
}
