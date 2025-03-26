namespace BookApp;
public interface IBookFactory
{
    IEnumerable<BookModel> GetBooks(int? bookId = 0);
    void AddBook(BookModel book);
    void ModifyBook(int? bookId, BookModel book);
    void DeleteBook(int bookId);
}
