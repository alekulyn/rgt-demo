using Microsoft.AspNetCore.Mvc;

namespace BookApp;

[Route("/api/books")]
[ApiController]
public class BookController : ControllerBase {
  [HttpGet]
  public ActionResult<IEnumerable<BookModel>> GetBook (int id) {

    return null;
  }

  [HttpGet]
  public ActionResult<IEnumerable<BookModel>> GetBooks () {

    return null;
  }

  [HttpPut]
  public ActionResult<IEnumerable<BookModel>> ModifyBook () {

    return null;
  }

  [HttpPost]
  public ActionResult<IEnumerable<BookModel>> AddBook (BookModel book) {

    return null;
  }
}
