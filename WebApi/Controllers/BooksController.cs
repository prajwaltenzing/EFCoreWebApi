using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        [HttpGet]
        public ActionResult<ApiResponse<List<Book>>> GetBooks()
        {
            EfCore8DbContext _context = new EfCore8DbContext();
            var books = _context.Books.ToList();
            return Ok(new ApiResponse<List<Book>>(true, 200, "Books retrieved successfully", books));
        }

        [HttpPost]
        public ActionResult<ApiResponse<int>> AddBook(Book book)
        {
            EfCore8DbContext _context = new EfCore8DbContext();
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(new ApiResponse<int>(true, 201, "Book added successfully", book.BookId));
        }
    }
}
