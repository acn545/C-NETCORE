using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;

namespace Passcode.Controllers{
    public class passcodeController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("Count") == null){
                HttpContext.Session.SetInt32("Count", 0);
            }
            
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            ViewBag.String = HttpContext.Session.GetString("random");
            return View();
        }
        [HttpGet]
        [Route("redirect")]
        public IActionResult redirect(){
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomString = new char[14];
            Random rand = new Random();
            for(int i = 0; i < randomString.Length; i++){
                randomString[i] = chars[rand.Next(chars.Length)];
            }
            string newString = new String(randomString);
            HttpContext.Session.SetString("random", newString);
            HttpContext.Session.SetInt32("Count", (int)HttpContext.Session.GetInt32("Count") + 1);
            return RedirectToAction("Index");
        }

    }             
}