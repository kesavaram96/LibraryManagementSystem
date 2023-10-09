using LibraryManagementSystem.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

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

                var checkAvailabel=_context.BooksInventories.SingleOrDefaultAsync(b => b.BookId == id);
                if (checkAvailabel == null)
                {
                    BooksInventory booksInventory = new BooksInventory
                    {
                        UserId = userId,
                        BookId = id,
                        Date = DateTime.Now,

                    };

                    _context.BooksInventories.Add(booksInventory);

                    book.AvailableCopies--;
                    _context.Update(book);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("Index");
                }
                return Content("Book already taken");

            }

            return BadRequest("No available copies");
    
        }

        public async Task<IActionResult> Surrender()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var applicationDbContext = _context.BooksInventories.Include(b=>b.Book).Where(m=>m.UserId==userId);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SurrenderBook(int id)
        {
            var Invent= _context.BooksInventories.Find(id);
            var BookId = Invent.BookId;
            var book = await _context.Books.FindAsync(BookId);

            if (book == null)
            {
                return NotFound();
            }

            book.AvailableCopies++;
            _context.Update(book);

            _context.BooksInventories.Remove(Invent);
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Surrender");
        }
    }
}
