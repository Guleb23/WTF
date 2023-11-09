using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        static List<Posts> Posts = new List<Posts>();


        public IActionResult Index()
        {
            return View("Index", Posts);
        }


        public IActionResult CreatePost(Guid id)
        {
            if (id != Guid.Empty)
            {
                Posts existPost = Posts.FirstOrDefault(p => p.Id == id);
                return View(model: existPost);
            }
            return View();
        }


        [HttpPost]
        public IActionResult CreatePost(Posts enry)
        {
            
            if (enry.Id == Guid.Empty)
            {
                Posts newPost = new Posts();
                newPost.Id = Guid.NewGuid();
                newPost.Description = enry.Description;
                newPost.Name = enry.Name;
                newPost.DatePublic = DateTime.Now;
                Posts.Add(newPost);
            }
            else
            {
                var exsPost = Posts.FirstOrDefault(post => post.Id == enry.Id);
                exsPost.Name = enry.Name;
                exsPost.Description = enry.Description;
            }

            return RedirectToAction("Index");
        }
    }
}
