using Assignment3.Models;
using Assignment3.Models.BLL;
using Assignment3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        //Get Answer/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {

            var viewModel = AnswerBLO.EditAnswer(id);


            return View(viewModel);

        }

        [ValidateAntiForgeryToken]
        [Authorize, HttpPost]
        public ActionResult Edit(EditAnswerViewModel editAnswer)
        {
            var id = (int)editAnswer.Id;
            var viewModel = AnswerBLO.EditAnswer(id);

            if (ModelState.IsValid)
            {

                using (var context = new ApplicationContext())
                {

                    var answer = context.Answers.Where(x => x.Id == editAnswer.Id).FirstOrDefault();

                    answer.AnswerText = editAnswer.Answer;
                    answer.AnswerDate = DateTime.Now;

                    context.SaveChanges();

                    
                    return RedirectToAction("Answer","Question", new { id = editAnswer.QuestionId });
                }

            }
            
            return View(viewModel);
        }





        




    }
}