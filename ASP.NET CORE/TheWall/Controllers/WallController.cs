using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace TheWall.Controllers
{
    public class WallController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost("CreateUser")]
        public IActionResult CreateUser(RegisterViewModel person){
            List<Dictionary<string, object>> allusers = DbConnector.Query("SELECT * FROM users");
            DateTime time = DateTime.Now;
            string dt = time.ToString("yyyy-MM-dd H:mm:ss");
            if(ModelState.IsValid){
                PasswordHasher<RegisterViewModel> hasher = new PasswordHasher<RegisterViewModel>();
                string hashedpw = hasher.HashPassword(person, person.password);
                string sql = $"INSERT INTO users(first_name, last_name, email, password, created_at, updated_at) VALUES ('{person.first_name}', '{person.last_name}', '{person.email}', '{hashedpw}', '{dt}', '{dt}')";
                DbConnector.Execute(sql);
                HttpContext.Session.SetString("email", person.email);
                HttpContext.Session.SetString("name", person.first_name + " " + person.last_name);
            }else{
                TryValidateModel(person);
                ViewBag.error = ModelState.Values;
                return RedirectToAction("Index");
            }
            return RedirectToAction("dashboard");
        }



        [HttpPost("loginUser")]
        public IActionResult loginUser(login person){
            List<Dictionary<string, object>> allusers = DbConnector.Query($"SELECT id,first_name, last_name, email, password FROM users WHERE email ='{person.email}'");
            PasswordHasher<login> hasher = new PasswordHasher<login>();
            if((allusers.Count == 0 || person.password == null) || hasher.VerifyHashedPassword(person, (string)allusers[0]["password"], person.password) == 0 ){
                ModelState.AddModelError("error", "Invalid Email or Password");
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid){
                HttpContext.Session.SetString("email", (string)allusers[0]["email"]);
                HttpContext.Session.SetString("name", (string)allusers[0]["first_name"] + " " + (string)allusers[0]["last_name"]);
                return RedirectToAction("dashboard");
            }
            return RedirectToAction("Index");
        }



        [HttpGet("dashboard")]
        public IActionResult dashboard(){
            if(HttpContext.Session.GetString("email") == null){
                return RedirectToAction("Index");
            }else{
                List<Dictionary<string, object>> messages = DbConnector.Query($"SELECT id, created_at, user_id, message FROM messages");
                List<Dictionary<string, object>> comments = DbConnector.Query($"SELECT created_at, user_id, message_id, comment FROM comments");
                List<Dictionary<string, object>> users = DbConnector.Query($"SELECT id, first_name, last_name FROM users");
                ViewBag.messages = messages;
                ViewBag.comments = comments;
                ViewBag.users = users;
                ViewBag.name = HttpContext.Session.GetString("name");
                ViewBag.email = HttpContext.Session.GetString("email");
                return View();
            }
        }
        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(messages msg){
            DateTime time = DateTime.Now;
            string dt = time.ToString("yyyy-MM-dd H:mm:ss");
            List<Dictionary<string, object>> user = DbConnector.Query($"SELECT id,first_name, last_name FROM users WHERE email ='{HttpContext.Session.GetString("email")}'");
            string sql = $"INSERT INTO messages(message, user_id, created_at, updated_at) VALUES('{msg.message}','{user[0]["id"]}', '{dt}', '{dt}' )";
            DbConnector.Execute(sql);
            return RedirectToAction("dashboard");
        }
        [HttpPost("CreateComment")]
        public IActionResult CreateComment(string comment, string id){
            DateTime time = DateTime.Now;
            string dt = time.ToString("yyyy-MM-dd H:mm:ss");
            Console.WriteLine(id);
            int ids = int.Parse(id);
            List<Dictionary<string, object>> user = DbConnector.Query($"SELECT id,first_name, last_name FROM users WHERE email ='{HttpContext.Session.GetString("email")}'");
            string sql = $"INSERT INTO comments(comment, user_id, message_id, created_at, updated_at) VALUES('{comment}','{user[0]["id"]}','{ids}' ,'{dt}', '{dt}' )";
            DbConnector.Execute(sql);
            return RedirectToAction("dashboard");
        }
    }
}
