using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
         public async Task<IActionResult> Borrow(int id)
        {
            var book= _context.Books.FirstOrDefaultAsync(m=>m.BookID==id);
            
            

           
            return View();
        }
        public async Task<IActionResult> Return()
        {


            return View();
        }
    }
}
