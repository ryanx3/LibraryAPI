using LibraryAPI.Communication.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : LibraryBaseController
{
    private static List<Book> _books = new List<Book>();

    [HttpPost]
    [ProducesResponseType(typeof(RequestCreateBookJson), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] RequestCreateBookJson request)
    {

        var guid = Guid.NewGuid().ToString();

        var book = new Book()
        {
            Id = guid,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            Title = request.Title
        };

        _books.Add(book);

        return Created(string.Empty, book);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetBooks()
    {
        return Ok(_books);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook([FromRoute] string id)
    {
        var bookRemove = _books.Find(book => book.Id == id);

        if (bookRemove != null)
        {
            _books.Remove(bookRemove);
            return NoContent();
        } else
        {
            return NotFound("Book not found");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RequestUpdateBookJson), StatusCodes.Status204NoContent)]
    public IActionResult UpdateBook([FromBody] RequestUpdateBookJson request, string id)
    {
        var book = _books.Find(book => book.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Author = request.Author;
        book.Title = request.Title;
        book.Stock = request.Stock;
        book.Price = request.Price;
        book.Genre = request.Genre;

        return NoContent();
    }
}
