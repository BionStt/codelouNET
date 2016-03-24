using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using louindiegames.Models;

namespace louindiegames.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Games
        public IActionResult Index()
        {
            var applicationDbContext = _context.Game.Include(g => g.Creator);
            return View(applicationDbContext.ToList());
        }

        // GET: Games/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var applicationDbContext = _context.Game.Include(g => g.Creator);
            Game game = applicationDbContext.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["CreatorID"] = new SelectList(_context.Set<Creator>(), "CreatorID", "Creator");
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                game.CreatorID = 1;
                _context.Game.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CreatorID"] = new SelectList(_context.Set<Creator>(), "CreatorID", "Creator", game.CreatorID);
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }
            // for dropdown
            object s = new SelectList(_context.Set<Creator>(), "CreatorID", "CreatorName", game.CreatorID);
            s.ToString();
            ViewData["CreatorID"] = new SelectList(_context.Set<Creator>(), "CreatorID", "CreatorName", game.CreatorID);
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {

                //query creator table
                //have a match
                game.CreatorID = 1;

                //no match
                _context.Creator.Add(new Creator { CreatorName = "name" });


                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CreatorID"] = new SelectList(_context.Set<Creator>(), "CreatorID", "Creator", game.CreatorID);
            return View(game);
        }

        // GET: Games/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Game game = _context.Game.Single(m => m.GameID == id);
            _context.Game.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
