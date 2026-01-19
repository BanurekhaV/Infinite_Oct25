using Microsoft.AspNetCore.Mvc;
using Core_OtherConcepts.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core_OtherConcepts.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubmitForm()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult SubmitForm(User user)
        //{
        //    if(user !=null)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ViewBag.Message = $"User Created : UserName : {user.UserName}, User Email :{ user.Email} ";
        //            ModelState.Clear();
        //            return View("Index");
        //        }
        //    }
        //    return View("Index");
        //}
        public IActionResult SubmitForm(IFormCollection frmc)
        {
            //uses keys to get the colection of form values
            var keys = frmc.Keys;

            //check if a key is existing
            if(frmc.ContainsKey("UserName") && frmc.ContainsKey("Email"))
            {
                if(frmc.TryGetValue("UserName", out StringValues username) &&
                    frmc.TryGetValue("Email",out StringValues email))
                {
                    ViewBag.Message= $"User Created : UserName : {username}, User Email :{email} ";
                }
                else
                {
                    ViewBag.Message = "UserName or Email not Found";
                }                             
            }
            else
            {
                ViewBag.Message = "Forms does not contain keys";
            }
            return View("Index");
      
        }     }
    }

