using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Flickr.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Flickr.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;

        }

        public IActionResult Create(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(posts => posts.Id == id);
            ViewBag.thisPost = thisPost;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment, int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(posts => posts.Id == id);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            comment.User = currentUser;
            comment.Post = thisPost;
            _db.Comment.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Details", "Posts", thisPost);

        }


    }
}