using Assignment3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3.Models.BLL
{
    public class AdminBLO
    {
        public static IList<UserViewModel> GetUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var role = context.Roles.SingleOrDefault(m => m.Name == "Admin");
                var users = context.Users.Where(x => x.Roles.All(r => r.RoleId != role.Id))
                    .Select(x => new UserViewModel
                    {
                      UserId = x.Id,
                      UserName = x.UserName,
                      LockoutEndDate = x.LockoutEndDateUtc

                    }).ToList();

                return users;
            }
        }

        public static CategoriesViewModel GetCategories()
        {

            return new CategoriesViewModel
            {
                Categories = QuestionsBLO.GetCategories()
            };
        }
    }
}