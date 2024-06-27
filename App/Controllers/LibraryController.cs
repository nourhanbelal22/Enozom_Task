using LibraryBL.Dtos;
using LibraryBL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("borrowBook")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowRequestModel request)
        {
            try
            {
               
                await _bookService.BorrowBookAsync(request.BookCopyId, request.StudentId,request.ExpectedReturnDate );
                return Ok("Book borrowed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("returnBook")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnRequestModel request)
        {
            try
            {
                await _bookService.ReturnBookAsync(request.BookCopyId, request.ReturnStatus);
                return Ok("Book Returned Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Report-CurrentStatue")]
        public async Task<IActionResult> GetAvailableCopies()
        {
            var availableCopies = await _bookService.GetBookCurrentStatus();
            return Ok(availableCopies);
        }
    }
}
