using AspNetCoreWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound(); // adres çubuğundan id gönderilmemişse ekrana sayfa bulunamadı hatası dön

            if (id != null) // Eğer adres çubuğunda Products controller a id gönderilmişse
            {
                return View(_databaseContext.Categories.Include(c => c.Products).FirstOrDefault(p => p.Id == id)); // Kategorilerden ıd si adres çubuğundan gelen id ile eşleşen kaydı getir ve o kategorinin ürünlerini de kayda include ile dahil et
            }
            return View();
        }
    }
}
