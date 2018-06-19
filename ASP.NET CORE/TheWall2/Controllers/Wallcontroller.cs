using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall2.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
namespace thewall2.Controllers
{
    public class WallController : Controller
    {
        [HttpGet("")]
        public IActionResult Index(){
            return View();
        }
        // Checks validations, if correct adds a new user to the users database
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(RegisterUser user){
            List<Dictionary<string, object>> users = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
            string usert = (string)users[0]["email"];
            // converts all strings to lowercase, then compairs the new user email to any user in the database, if they exsist this returns an error.
            if(usert.ToLower() == user.email.ToLower()){
                ModelState.AddModelError("EmailTaken", "The Email address has already been used");
                ViewBag.error = "The Email address has already been used";
                return View("Index");
            }
            if(ModelState.IsValid){
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                string hashedPassword = hasher.HashPassword(user, user.password);
                string sql = $"INSERT INTO users(first_name, last_name, email, password, created_at, updated_at)VALUES('{user.first_name}','{user.last_name}', '{user.email}','{hashedPassword}',NOW(), NOW() )";
                DbConnector.Execute(sql);
                HttpContext.Session.SetString("email", user.email);
                HttpContext.Session.SetString("name", user.first_name + " " + user.last_name);
                return RedirectToAction("Index");
            }
               // TryValidateModel(user);
               return View("Index");
        }



        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LoginUser user){
            List<Dictionary<string, object>> users = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            if((users.Count == 0 || user.password == null) || hasher.VerifyHashedPassword(user, (string)users[0]["password"], user.password) == 0){
                ModelState.AddModelError("logemail", "Invalid Email or password");
                ViewBag.error = "Invalid Email or password";
            }
            if(ModelState.IsValid){
                HttpContext.Session.SetString("email", user.email);
                HttpContext.Session.SetString("name", users[0]["first_name"] + " " + users[0]["last_name"]);
                HttpContext.Session.SetInt32("user_id", (int)users[0]["id"]);
                return RedirectToAction("dashboard");
            }
            return View("Index");
        }


        [HttpGet("dashboard")]
        public IActionResult dashboard(){
            if(HttpContext.Session.GetString("email") != null){
                ViewBag.messages = DbConnector.Query($@"SELECT messages.id, messages.created_at, messages.message, users.first_name, users.last_name FROM messages JOIN users ON messages.user_id = users.id order by created_at DESC");
                ViewBag.comments = DbConnector.Query($@"SELECT comments.id, comments.comment, comments.created_at, users.first_name, users.last_name, comments.message_id FROM comments JOIN messages ON comments.message_id = messages.id JOIN users ON comments.user_id = users.id order by created_at DESC ");
                ViewBag.name = HttpContext.Session.GetString("name");
                ViewBag.email = HttpContext.Session.GetString("email");
                ViewBag.id = HttpContext.Session.GetInt32("user_id");
               return View();
            }
            return View("Index");
        }
        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(CreateMessage newMessage){
            if(ModelState.IsValid){
                string sql = $@"INSERT INTO messages(message, user_id, created_at, updated_at) VALUES ('{newMessage.message}', '{HttpContext.Session.GetInt32("user_id")}', NOW(), NOW())";
                DbConnector.Execute(sql);
            }
            return RedirectToAction("dashboard");
        }


        [HttpPost("CreateComment")]
        public IActionResult CreateComment(CreateComment newComment){
            if(ModelState.IsValid){
                string sql = $@"INSERT INTO comments(comment, user_id, created_at, updated_at, message_id) VALUES ('{newComment.comment}', '{HttpContext.Session.GetInt32("user_id")}', NOW(), NOW(), '{newComment.message_id}')";
                DbConnector.Execute(sql);
            }
            return RedirectToAction("dashboard");
        }
        [HttpGet("logout")]
        public IActionResult LogOut(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
