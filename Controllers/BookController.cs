using LibraryAPI.Communication.Requests;
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
}
