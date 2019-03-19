using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            var ihvw = new IndexHomeViewModel {
                FamilyName = user.FamilyName,
                FirstName = user.FirstName,
                Birthday = user.Birthday,
                SelectedValue = user.Location,
                Gender = user.Gender,
                Noticed = user.Noticed,
                Areas = new SelectList(_context.Areas, "Value", "Text")
            };
            return View(ihvw);
        }

        [HttpPost]
        public ActionResult Index(IndexHomeViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            if (ModelState.IsValid)
            {
                user.Birthday = viewModel.Birthday;
                user.Location = viewModel.SelectedValue;
                user.Gender = viewModel.Gender;
                user.Noticed = viewModel.Noticed;
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            var ihvw = new IndexHomeViewModel {
                Birthday = user.Birthday,
                SelectedValue = user.Location,
                Gender = user.Gender,
                Noticed = user.Noticed,
                Areas = new SelectList(_context.Areas, "Value", "Text")
            };
            return View(ihvw);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}