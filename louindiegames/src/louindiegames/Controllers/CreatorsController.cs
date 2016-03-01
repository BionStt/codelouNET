using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using louindiegames.Models;

namespace louindiegames.Controllers
{
    public class CreatorsController : Controller
    {
        private ApplicationDbContext _context;

        public CreatorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Creators
        public IActionResult Index()
        {
            return View(_context.Creator.ToList());
        }

        // GET: Creators/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Creator creator = _context.Creator.Single(m => m.CreatorID == id);
            if (creator == null)
            {
                return HttpNotFound();
            }

            return View(creator);
        }

        // GET: Creators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Creators/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Creator creator)
        {
            if (ModelState.IsValid)
            {
                _context.Creator.Add(creator);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creator);
        }

        // GET: Creators/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Creator creator = _context.Creator.Single(m => m.CreatorID == id);
            if (creator == null)
            {
                return HttpNotFound();
            }
            return View(creator);
        }

        // POST: Creators/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Creator creator)
        {
            if (ModelState.IsValid)
            {
                _context.Update(creator);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creator);
        }

        // GET: Creators/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Creator creator = _context.Creator.Single(m => m.CreatorID == id);
            if (creator == null)
            {
                return HttpNotFound();
            }

            return View(creator);
        }

        // POST: Creators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Creator creator = _context.Creator.Single(m => m.CreatorID == id);
            _context.Creator.Remove(creator);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
