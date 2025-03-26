
namespace BookApp;

public class BookFactory : IBookFactory
{
  public void DeleteBook(int id) {
  }

  public void AddBook(BookModel book) {
  }

  public void ModifyBook(int? id, BookModel book) {
  }

  public IEnumerable<BookModel> GetBooks(int? id) {
    return null;
  }
}
