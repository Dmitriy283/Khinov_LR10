using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Khinov_LR10.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Khinov_LR10.Models;

namespace Khinov_LR10.Controllers
{
    public class HomeController : Controller
    {
        DateTime time;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (user.Day.CompareTo(DateTime.Now) <= time.CompareTo(DateTime.Now))
            {
                ModelState.AddModelError("Day", "You can't enroll in the past!");
            }
            else if (user.productConsult == "Основи" && user.Day.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("Day", "You cannot go to this course in Monday, and Weekends too!");
            }
            else if (user.Day.DayOfWeek == DayOfWeek.Sunday || user.Day.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError("Day", "Weekends are weekends, sign up on weekdays!");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Information", user);
            }
            return View(user);
        }
        public IActionResult Information(UserModel user)
        {
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

