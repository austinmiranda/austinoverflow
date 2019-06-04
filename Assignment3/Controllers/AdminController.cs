using Assignment3.Models;
using Assignment3.Models.BLL;
using Assignment3.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }


        public AdminController(ApplicationUserManager userManager)
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

        // GET: Admin
        public ActionResult Index()
        {
            var viewModel = AdminBLO.GetUsers();
            return View(viewModel);
        }

        public async Task<ActionResult> Unlock(string id, string returnUrl)
        {

            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                await UserManager.SetLockoutEndDateAsync(user.Id, new DateTimeOffset(DateTime.UtcNow));

                return Redirect(returnUrl);
            }
        }

        public ActionResult Categories()
        {
            var viewModel = AdminBLO.GetCategories();
            return View(viewModel);
        }


        //Post
        [ValidateAntiForgeryToken]
        [Authorize, HttpPost]
        public ActionResult AddCategory(CategoriesViewModel request)
        {
           
            if (ModelState.IsValid)
            {

                using (var context = new ApplicationContext())
                {

                    Category c = new Category()
                    {
                        Name = request.AddCat.Name

                    };

                    context.Categories.Add(c);
                    context.SaveChanges();

                    
                    return RedirectToAction("Categories");
                }

            }
            else
              
            return RedirectToAction("Categories");
        }



        [Authorize]
        public ActionResult RemoveCategory(int id, string returnUrl)
        {
            using (var context = new ApplicationContext())
            {
                var catToRemove = context.Categories.Where(x => x.Id == id).SingleOrDefault();
                if (catToRemove != null)
                {
                    context.Categories.Remove(catToRemove);
                    context.SaveChanges();
                }
            

            }
            // return RedirectToAction("Index");
            return Redirect(returnUrl);

        }




    }
}