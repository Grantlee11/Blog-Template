using Microsoft.AspNetCore.Mvc;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MyBlog> objArticleList = _db.Blogs;
            return View(objArticleList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyBlog obj)
        {
            _db.Blogs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Manage");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var article = _db.Blogs.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MyBlog obj)
        {
            _db.Blogs.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Manage");
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var article = _db.Blogs.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MyBlog obj)
        {
            _db.Blogs.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Manage");
        }

        public IActionResult Manage()
        {
            IEnumerable<MyBlog> objArticleList = _db.Blogs;
            return View(objArticleList);
        }

        [HttpGet]
        public IActionResult Article(int id)
        {
            var article = _db.Blogs.Find(id);
            return View(article);
        }
    }
}
