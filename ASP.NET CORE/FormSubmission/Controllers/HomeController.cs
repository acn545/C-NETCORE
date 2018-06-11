using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;


namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM user");
            ViewBag.users = AllUsers;
            ViewBag.error = ModelState.Values;
            return View();
        }
        [HttpPost("register")]
        public IActionResult register(User ru){
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM user");
            ViewBag.users = AllUsers;
            if(ModelState.IsValid){
                PasswordHasher<User> hasher =  new PasswordHasher<User>();
                string hashedPW = hasher.HashPassword(ru, ru.password);
                string sql = $"INSERT INTO user (first_name, last_name, age, email, password) VALUES('{ru.first_name}', '{ru.last_name}', '{ru.Age}', '{ru.email}', '{hashedPW}' )";
                DbConnector.Execute(sql);

            }else{
                TryValidateModel(ru);
                ViewBag.error = ModelState.Values;
                return View("Index"); 
            }
            return RedirectToAction("Index");

        }
    }
}
