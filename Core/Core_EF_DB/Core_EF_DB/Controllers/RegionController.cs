using Core_EF_DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_EF_DB.Controllers
{
    public class RegionController : Controller
    {
        private readonly NorthwindContext _context;

        public RegionController(NorthwindContext context)
        {
           _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionID, RegionDescription")] Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var region = await _context.Regions.FirstOrDefaultAsync(r => r.RegionId == id);
            if (region == null)
            {
                return NotFound();            
            }
            return View(region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, [Bind("RegionId,RegionDescription")] Region region)
        {
            if(id != region.RegionId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(region);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(region);
        }
    }
}
