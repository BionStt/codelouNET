using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using louindiegames.Models;

namespace louindiegames.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Reviews
        public IActionResult Index()
        {
            var applicationDbContext = _context.Review.Include(r => r.Game);
            return View(applicationDbContext.ToList());
        }

        // GET: Reviews/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Review review = _context.Review.Single(m => m.ReviewID == id);
            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {

                review.ReviewID = 1;
                _context.Review.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", review.GameID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Review review = _context.Review.Single(m => m.ReviewID == id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", review.GameID);
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                //added this line here bc reasons
                review.ReviewID = 1;
                // no match
                _context.Review.Add( new Review { ReviewTitle = "Review Title" });
                _context.Update(review);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", review.GameID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Review review = _context.Review.Single(m => m.ReviewID == id);
            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Review review = _context.Review.Single(m => m.ReviewID == id);
            _context.Review.Remove(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
