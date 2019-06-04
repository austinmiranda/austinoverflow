using Assignment3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Models.BLL
{
    public class QuestionsBLO
    {
        public static IList<CategoryViewModel> GetCategories()
        {
            using (var context = new ApplicationContext())
            {
                var categories = context.Categories
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,

                    }).OrderBy(x => x.Name).ToList();

                return categories;
            }
        }



        public static IList<QuestionViewModel> GetQuestions()
        {
            using (var context = new ApplicationContext())
            {
                var questions = context.Questions
                    .Select(x => new QuestionViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category = x.Category.Name,
                        QuestionDate = x.QuestionDate,
                        ViewCount = x.ViewCount,
                        AnswerCount = x.AnswerCount,
                        VoteCount = x.VoteCount,
                        UserName = x.UserName

                    }).ToList();

                return questions;
            }
        }


        public static IList<VoteViewModel> GetUserVotes(string uid)
        {
            using (var context = new ApplicationContext())
            {
                var votes = context.Votes.Where(x => x.UserId == uid)
                    .Select(x => new VoteViewModel
                    {
                        QuestionId = x.Question.Id,
                        UserId = x.UserId,
                        VoteDown =x.VoteDown,
                        VoteUp = x.VoteUp

                    }).ToList();

                return votes;
            }
        }

        public static QuestionAddViewModel AddQuestion()
        {
            return new QuestionAddViewModel
            {
                    Categories = GetCategoriesSL()
            };
        }

        public static SelectList GetCategoriesSL()
        {
            using (var context = new ApplicationContext())
            {
                var categories = context.Categories.ToList().Select(
                    x => new { Value = x.Id, Text = x.Name });

                return new SelectList(categories, "Value", "Text");
            }
        }

        public static QuestionAnswerViewModel AnswerQuestion(int? id)
        {

            addView(id);


            return new QuestionAnswerViewModel
            {
                Question = GetQuestion(id),
                Answers = GetAnswers(id)
            };
        }

        public static QuestionAnswerViewModel AnswerQuestionR(int? id)
        {

            //addView(id);


            return new QuestionAnswerViewModel
            {
                Question = GetQuestion(id),
                Answers = GetAnswers(id)
            };
        }

        public static IList<AnswerViewModel> GetAnswers(int? id)
        {
            using (var context = new ApplicationContext())
            {
                var answers = context.Answers
                    .Where(x => x.Question.Id == id)
                    .Select(x => new AnswerViewModel
                    {
                        Id = x.Id,
                        Answer = x.AnswerText,
                        AnswerDate = x.AnswerDate,
                        QuestionId = id,
                        UserName = x.UserName,
                        UserId = x.UserId

                    }).ToList();

                return answers;
            }
        }

        public static QuestionViewModel GetQuestion(int? id)
        {
            using (var context = new ApplicationContext())
            {
                var question = context.Questions
                    .Where(x => x.Id == id)
                    .Select(x => new QuestionViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category = x.Category.Name,
                        QuestionDate = x.QuestionDate,
                        ViewCount = x.ViewCount,
                        AnswerCount = x.AnswerCount,
                        VoteCount = x.VoteCount,
                        UserName = x.UserName

                    }).FirstOrDefault();

                return question;
            }
        }

        public static void addView(int? id)
        {
            using (var context = new ApplicationContext())
            {
                var question = context.Questions
                    .Where(x => x.Id == id).SingleOrDefault();

                question.ViewCount += 1;

                context.SaveChanges();

            }
        }

        public static void addAnswerCount(int? id)
        {
            using (var context = new ApplicationContext())
            {
                var question = context.Questions
                    .Where(x => x.Id == id).SingleOrDefault();

                question.AnswerCount += 1;

                context.SaveChanges();

            }
        }




    }
}