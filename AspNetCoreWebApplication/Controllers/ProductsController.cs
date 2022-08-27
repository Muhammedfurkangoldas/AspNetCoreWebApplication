using AspNetCoreWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(int? id)
        {

            return View(_databaseContext.Products.ToList());
        }
        public async Task<IActionResult> DetailAsync(int? id)
        {
            if (id == null) return BadRequest();// Eğer Adres çubuğunda id değeri gönderilmemişse geriye geçersiz istek hatası dön.
           
            return View(await _databaseContext.Products.Include("Brand").Include(c=>c.Category).FirstOrDefaultAsync(p=>p.Id == id));
        }
    }
}
