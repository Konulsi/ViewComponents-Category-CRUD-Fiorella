using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework_Slider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;
        public CategoryController(ICategoryService categoryService, AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _categoryService.GetAll());
        }


        [HttpGet]
        public IActionResult Create()     /*async-elemirik cunku data gelmir databazadan*/
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)     // bazaya neyise save edirik deye asinxron olmalidi
        {
            await _context.Categories.AddAsync(category);  //bazadaki categorie tablesine category ni add edir liste
            await _context.SaveChangesAsync();    //save edir bazaya 
            return RedirectToAction(nameof(Index));
        }


    }
}
