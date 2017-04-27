using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flickr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Flickr.Controllers
{
    [Authorize]
    public class PostsTagsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsTagsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.PostsTags.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.PostId = new SelectList(_db.Posts, "Id", "Description");
            ViewBag.TagId = new SelectList(_db.Tags, "TagId","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostsTags postsTags)
        {
            _db.PostsTags.Add(postsTags);
            _db.SaveChanges();
            return RedirectToAction("Index", "Pictures");
        }
    }
}