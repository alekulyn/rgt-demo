SELECT
  author,
  title,
  sold
FROM main.books
WHERE book_id = @id

