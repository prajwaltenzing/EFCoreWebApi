using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<Book>> GetBook(int id)
        {
            EfCore8DbContext _context = new EfCore8DbContext();

            var existingBook = _context.Books.FirstOrDefault(book => book.BookId == id);

            if (existingBook == null)
            {
                return NotFound(new ApiResponse<Book>(false, 404, "BookId does not exist", null));
            }

            return Ok(new ApiResponse<Book>(true, 200, "Retrieved book successfully", existingBook));
        }


        [HttpPut]
        public ActionResult<ApiResponse<bool>> UpdateBook(Book book)
        {

            EfCore8DbContext _context = new EfCore8DbContext();
            var existingBook = _context.Books.Find(book.BookId);
            if (existingBook == null) 
            {
                return NotFound(new ApiResponse<bool>(false, 404, "BookId does not exist", false));
            }
            existingBook!.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.Isbn = book.Isbn;
            existingBook.Price = book.Price;

            _context.SaveChanges();
            return Ok(new ApiResponse<bool>(true, 200, "Book Updated successfully", true));

        }

        //[HttpDelete("{Id}")] Route parameter
        [HttpDelete]
        public ActionResult<ApiResponse<bool>> DeleteBook([FromQuery] int id)
        {
            EfCore8DbContext _context = new EfCore8DbContext();
            var existingBook = _context.Books.FirstOrDefault(book => book.BookId == id);
            if (existingBook == null)
            {
                return NotFound(new ApiResponse<bool>(false, 404, "BookId does not exist", false));
            }
            _context.Remove(existingBook);

            _context.SaveChanges();
            return Ok(new ApiResponse<bool>(true, 200, "Book deleted successfully", true));
        }
    }
}
