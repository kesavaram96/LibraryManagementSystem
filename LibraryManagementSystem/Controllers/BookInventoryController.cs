using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryManagementSystem.Controllers
{
    public class BookInventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookInventoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Books.Include(b => b.Author);
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpGet]
         public async Task<IActionResult> Borrow(int id)
        {
       
            var book = await _context.Books.FindAsync(id);
            
            if (book == null)
            {
                return NotFound(); 
            }

            if (book.AvailableCopies > 0)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null) 
                {
                    return Redirect("~/Identity/Account/Login");
                }
  
           

                book.AvailableCopies--;
                _context.Update(book);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index");
            }

            return BadRequest("No available copies");
    
        }
    
    }
}
