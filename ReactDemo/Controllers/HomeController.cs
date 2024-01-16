using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;
        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "burg",
                    Text = "burgey burgason"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "flurg",
                    Text = "flurgey flurason"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "turg",
                    Text = "turgey turgason"
                },
            };
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Comments()
        {
            return Json(_comments);
        }
        public IActionResult Index()
        {
            return View(_comments);
        }
        [Route("comments/new")]
        [HttpPost]
        public IActionResult AddComment(CommentModel comment)
        { 
            //create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success");
        }
    }
}
