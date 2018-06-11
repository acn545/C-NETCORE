using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.error = ModelState.Values;
            return View();
        }
        [HttpPost("register")]
        public IActionResult register(User ru){
            if(ModelState.IsValid){
                PasswordHasher<User> hasher =  new PasswordHasher<User>();
                string hashedPW = hasher.HashPassword(ru, ru.password);
                string sql = $"INSERT INTO user (first_name, last_name, email, password) VALUES('{ru.first_name}', '{ru.last_name}',  '{ru.email}', '{hashedPW}' )";
                DbConnector.Execute(sql);
                HttpContext.Session.SetString("email", "ru.email");
                ViewBag.email = HttpContext.Session.GetString("email");
                HttpContext.Session.SetString("register", "registration succesful");
                HttpContext.Session.SetString("login", " login successful");
            }else{
                TryValidateModel(ru);
                ViewBag.error = ModelState.Values;
                return View("Index");
            }
            return RedirectToAction("dashboard");
        }
        [HttpPost("login")]
        public IActionResult login(LoginUser ru){
            List<Dictionary<string, object>> users = DbConnector.Query($"SELECT id,email, password FROM user WHERE email = '{ru.email}'");
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            if((users.Count == 0 || ru.password == null) || hasher.VerifyHashedPassword(ru, (string)users[0]["password"], ru.password) == 0){
                ModelState.AddModelError("error", "invalid email or password");
            }
             if(ModelState.IsValid){
                HttpContext.Session.SetString("email", (string)users[0]["email"]);
                HttpContext.Session.SetString("login", " login successful");
                HttpContext.Session.SetString("register", " ");
                return RedirectToAction("dashboard");
             }
            return View("Index");
        }
        [HttpGet("dashboard")]
        public IActionResult dashboard(){
            if (HttpContext.Session.GetString("email") == null){
                return RedirectToAction("");
            }
            ViewBag.login = HttpContext.Session.GetString("login");
            ViewBag.register = HttpContext.Session.GetString("register");
            ViewBag.email = HttpContext.Session.GetString("email");
            return View();
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
