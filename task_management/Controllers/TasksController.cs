using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_management.Models;
namespace task_management.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include("Team");
            ViewBag.Tasks = tasks;
            return View();
        }

        // GET Impicit
        public ActionResult New()
        {
            var teams = from cat in db.Teams
                        select cat;

            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public ActionResult New(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Show(int id)
        {
            Task task = db.Tasks.Find(id);
            ViewBag.Task = task;
            ViewBag.Team = task.team;
            return View();
        }


        public ActionResult Edit(int id)
        {
            Task task = db.Tasks.Find(id);
            ViewBag.Tasks = task;
            ViewBag.Team = task.Team;
            var tasks = from cat in db.Tasks select cat;
            ViewBag.Tasks = tasks;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Task requestTask)
        {
            try
            {
                Task task = db.Tasks.Find(id);
                if (TryUpdateModel(task))
                {
                    task.Title = requestTask.Title;
                    task.Content = requestTask.Content;
                    task.StartDate = requestTask.StartDate;
                    task.EndDate = requestTask.EndDate;
                    task.Status = requestTask.Status;
                    db.SaveChanges();
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
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}