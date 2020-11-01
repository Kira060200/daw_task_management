using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_management.Models;
namespace task_management.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include("Task");
            ViewBag.Comments = comments;
            return View();
        }

        // GET Impicit
        public ActionResult New()
        {
            var tasks = from cat in db.Tasks
                             select cat;

            ViewBag.Tasks = tasks;
            return View();
        }

        [HttpPost]
        public ActionResult New(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Show(int id)
        {
            Comment comment = db.Comments.Find(id);
            ViewBag.Comment = comment;
            ViewBag.Category = comment.Category;
            return View();
        }


        public ActionResult Edit(int id)
        {
            Comment comment = db.Comments.Find(id);
            ViewBag.Comments = comment;
            ViewBag.Task = comment.Task;
            var tasks = from cat in db.Tasks select cat;
            ViewBag.Tasks = tasks;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Comment requestArticle)
        {
            try
            {
                Comment comment = db.Comments.Find(id);
                if (TryUpdateModel(comment))
                {
                    /*article.Title = requestArticle.Title;
                    article.Content = requestArticle.Content;
                    article.Date = requestArticle.Date;
                    article.CategoryId = requestArticle.CategoryId;
                    db.SaveChanges();*/
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}