using Assignment3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3.Models.BLL
{
    public class AnswerBLO
    {
        public static EditAnswerViewModel EditAnswer(int? id)
        {

            return GetAnswer(id);
           
        }


        public static EditAnswerViewModel GetAnswer(int? id)
        {
            using (var context = new ApplicationContext())
            {
                var answer = context.Answers
                    .Where(x => x.Id == id)
                    .Select(x => new EditAnswerViewModel
                    {
                        Id = x.Id,
                        Answer = x.AnswerText,
                        QuestionId = x.Question.Id
                        

                    }).FirstOrDefault();

                return answer;
            }
        }

    }
}