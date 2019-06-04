using Assignment3.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = QuestionsBLO.GetQuestions();
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Each month, over 50 million developers come to Stack Overflow to learn, share their knowledge, and build their careers.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";

            return View();
        }
    }
}