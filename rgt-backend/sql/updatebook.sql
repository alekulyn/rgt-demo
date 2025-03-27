UPDATE main.books
SET
  author = @author,
  title = @title
WHERE
  book_id = @id
