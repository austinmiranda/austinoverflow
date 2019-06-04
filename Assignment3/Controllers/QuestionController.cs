using Assignment3.Models;
using Assignment3.Models.BLL;
using Assignment3.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationUserManager _userManager;

        public QuestionController()
        {
        }


        public QuestionController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Question
        public ActionResult Index()
        {
            var viewModel = QuestionsBLO.GetQuestions();

            //if(User.Identity.GetUserId<string>() != null)
            //{
            //    ViewBag.userVotes = QuestionsBLO.GetUserVotes(User.Identity.GetUserId<string>());
            //}

            return View(viewModel);
        }

        //GET: Question/Categories
        public ActionResult Categories()
        {
            var viewModel = QuestionsBLO.GetCategories();
            return View(viewModel);
        }

        //Get Question/Add
        [Authorize]
        public ActionResult Add()
        {

                var viewModel = QuestionsBLO.AddQuestion();
                    
              
                return View(viewModel);
          
        }

        [ValidateAntiForgeryToken]
        [Authorize,HttpPost]
        public async Task<ActionResult> Add(QuestionAddViewModel request)
        {

            var viewModel = QuestionsBLO.AddQuestion();
            if (ModelState.IsValid)
                {

                    using(var context = new ApplicationContext())
                    {
                    var category = context.Categories.Where(x => x.Id == request.CategoryId.Value).SingleOrDefault();
                    var userId = User.Identity.GetUserId<string>();
                    var user = await UserManager.FindByIdAsync(userId);

                    Question q = new Question()
                    {
                        Name = request.Name,
                        Category = category,
                        QuestionDate = DateTime.Now,
                        AnswerCount = 0,
                        ViewCount = 0,
                        VoteCount = 0,
                        UserId = userId,
                        UserName = user.UserName
                    };

                    context.Questions.Add(q);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                    
                }
                else
                    return View(viewModel);
            
          
        }


        //Get Question/Answer
        public ActionResult Answer(int id)
        {

            var viewModel = QuestionsBLO.AnswerQuestion(id);


            return View(viewModel);

        }

        //Post
        [ValidateAntiForgeryToken]
        [Authorize,HttpPost]
        public async Task<ActionResult> Answer(QuestionAnswerViewModel request)
        {
            // var viewModel = QuestionsBLO.AnswerQuestion(id);
            var id = (int)request.AddAns.QuestionId;
            var viewModel = QuestionsBLO.AnswerQuestionR(id);
            if (ModelState.IsValid)
            {

                using (var context = new ApplicationContext())
                {

                    var question = context.Questions.Where(x => x.Id == request.AddAns.QuestionId).SingleOrDefault();
                    var userId = User.Identity.GetUserId<string>();
                    var user = await UserManager.FindByIdAsync(userId);


                    Answer a = new Answer()
                    {
                        AnswerText = request.AddAns.Answer,
                        AnswerDate = DateTime.Now,
                        Question = question,
                        UserId = userId,
                        UserName = user.UserName
                        
                    };


                    question.AnswerCount += 1;
                    context.Answers.Add(a);
                    context.SaveChanges();

                    //return View("Answer", new { id = question.Id });
                    return RedirectToAction("Answer", new { id = question.Id });
                }

            }
            else
                return View(viewModel);
        }


        
        [Authorize]
        public async Task<ActionResult> Upvote(int id, string returnUrl)
        {
            using (var context = new ApplicationContext())
            {
                var userId = User.Identity.GetUserId<string>();
                var user = await UserManager.FindByIdAsync(userId);
                var question = context.Questions.Where(x => x.Id == id).SingleOrDefault();

                var vote = context.Votes.Where(x => x.Question.Id == id && x.UserId == userId).SingleOrDefault();
          
                if (vote == null)
                {
                    Vote v = new Vote()
                    {
                        Question = question,
                        UserId = userId,
                        VoteUp = true,
                        VoteDown = false
                    };

                    context.Votes.Add(v);
                    question.VoteCount += 1;
                    context.SaveChanges();
                }
                else
                {
                   if (!vote.VoteUp && vote.VoteDown)
                    {
                        vote.VoteUp = true;
                        vote.VoteDown = false;
                        question.VoteCount += 2;
                        context.SaveChanges();
                    }
                }

            }
             
                return Redirect(returnUrl);
            
        }

        [Authorize]
        public async Task<ActionResult> Downvote(int id, string returnUrl)
        {
            using (var context = new ApplicationContext())
            {
                var userId = User.Identity.GetUserId<string>();
                var user = await UserManager.FindByIdAsync(userId);
                var question = context.Questions.Where(x => x.Id == id).SingleOrDefault();

                var vote = context.Votes.Where(x => x.Question.Id == id && x.UserId == userId).SingleOrDefault();
              
                if (vote == null)
                {
                    Vote v = new Vote()
                    {
                        Question = question,
                        UserId = userId,
                        VoteUp = false,
                        VoteDown = true
                    };

                    context.Votes.Add(v);
                    question.VoteCount -= 1;
                    context.SaveChanges();
                }
                else
                {
                    if (vote.VoteUp && !vote.VoteDown)
                    {
                        vote.VoteDown = true;
                        vote.VoteUp = false;
                        question.VoteCount -= 2;
                        context.SaveChanges();
                    }
                }
            }
                return Redirect(returnUrl);

            
        }




    }
}