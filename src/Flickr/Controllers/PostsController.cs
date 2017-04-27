using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Flickr.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Flickr.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Posts.Where(x => x.User.Id == currentUser.Id));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            post.User = currentUser;
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllPosts()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Posts.ToList());

        }

        public IActionResult Details(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(post => post.Id == id);
            return View(thisPost);
        }

        public IActionResult Delete(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(posts => posts.Id == id);
            return View(thisPost);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(posts => posts.Id == id);
            _db.Posts.Remove(thisPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(items => items.Id == id);
            return View(thisPost);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
