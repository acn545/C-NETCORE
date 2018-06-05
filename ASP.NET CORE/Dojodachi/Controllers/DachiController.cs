using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;

namespace Dojodachi.Controllers{
    public class dachiController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("feed") == null){
                HttpContext.Session.SetInt32("feed", 3);
                HttpContext.Session.SetInt32("happiness",20);
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("energy", 50);
            }
            if(HttpContext.Session.GetInt32("happiness") >= 100 && HttpContext.Session.GetInt32("fullness") >= 100 || HttpContext.Session.GetInt32("happiness") <= 0 && HttpContext.Session.GetInt32("fullness") <= 0){
                return RedirectToAction("winlose");
            }
            ViewBag.feed = HttpContext.Session.GetInt32("feed");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.action = HttpContext.Session.GetString("action");
            return View();
        }
        [HttpGet]
        [Route("feed")]
        public IActionResult feed(){
            Random rand = new Random();
            int chance = rand.Next(1,4);
            if(chance == 1){
                HttpContext.Session.SetString("action", "DojoDachi did not want to Eat!!");
                if(HttpContext.Session.GetInt32("feed") > 0){
                    HttpContext.Session.SetInt32("feed", (int)HttpContext.Session.GetInt32("feed") -1);
                }else{
                    HttpContext.Session.SetString("action", "You have no Meals Left, you cannot feed your DojoDachi, try going to work to get more meals");
                }
            }else{
                if(HttpContext.Session.GetInt32("feed") > 0){
                    HttpContext.Session.SetInt32("feed", (int)HttpContext.Session.GetInt32("feed") -1);
                    int feed = (int)HttpContext.Session.GetInt32("feed");
                    int full = rand.Next(5,10);
                    HttpContext.Session.SetInt32("fullness", (int)HttpContext.Session.GetInt32("fullness") + full);
                    HttpContext.Session.SetString("action", "You Fed your DojoDachi a meal, this added " + full + " fullness");
                }else{
                    HttpContext.Session.SetString("action", "You have no Meals Left, you cannot feed your DojoDachi, try going to work to get more meals");
                }
            }
            return RedirectToAction("index");
            
        }
        [HttpGet]
        [Route("play")]
        public IActionResult play(){
            Random rand = new Random();
            int chance = rand.Next(1,4);
            if(chance == 1){
                HttpContext.Session.SetString("action", "DojoDachi did not want to Play!!");
                if(HttpContext.Session.GetInt32("energy") > 0){
                    HttpContext.Session.SetInt32("energy", (int)HttpContext.Session.GetInt32("energy") -5);
                }else{
                    HttpContext.Session.SetString("action", "DojoDachi has no Energy! please Sleep!!");
                }
            }else{
                if(HttpContext.Session.GetInt32("energy") > 0){
                    HttpContext.Session.SetInt32("energy", (int)HttpContext.Session.GetInt32("energy") - 5);
                    int happy = rand.Next(5,10);
                    HttpContext.Session.SetInt32("happiness", (int)HttpContext.Session.GetInt32("happiness") + happy);
                    HttpContext.Session.SetString("action", "You played with DojoDachi, Energy decreased by 5 and happiness increased by " + happy);

                }else{
                    HttpContext.Session.SetString("action", "DojoDachi has no Energy! please Sleep!!");
                }
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("work")]
        public IActionResult work(){
            Random rand = new Random();
            if(HttpContext.Session.GetInt32("energy") > 0){
                    HttpContext.Session.SetInt32("energy", (int)HttpContext.Session.GetInt32("energy") - 5);
                    int work = rand.Next(1,3);
                    HttpContext.Session.SetInt32("feed", (int)HttpContext.Session.GetInt32("feed") + work);
                    HttpContext.Session.SetString("action", "DojoDachi went to work and has earned " + work + " meals, and used 5 energy.");

                }else{
                    HttpContext.Session.SetString("action", "DojoDachi has no Energy! please Sleep!!");
                }
            return RedirectToAction("index");
        }
          [HttpGet]
        [Route("sleep")]
        public IActionResult sleep(){
            Random rand = new Random();
                    HttpContext.Session.SetInt32("energy", (int)HttpContext.Session.GetInt32("energy") + 15);
                    HttpContext.Session.SetInt32("happiness", (int)HttpContext.Session.GetInt32("happiness") - 5);
                    HttpContext.Session.SetInt32("fullness", (int)HttpContext.Session.GetInt32("fullness") - 5);
                    HttpContext.Session.SetString("action", "DojoDachi went to sleep, energy increased by + 15, Happiness and fullness decreased by - 5");

            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("winlose")]
        public IActionResult winlose(){
            if(HttpContext.Session.GetInt32("happiness") >= 100 && HttpContext.Session.GetInt32("fullness") >= 100){
                HttpContext.Session.SetString("action", "Congratulations you Win!");
                ViewBag.win = "YOU WIN!!!!!";
            }
            if(HttpContext.Session.GetInt32("happiness") <= 0 && HttpContext.Session.GetInt32("fullness") <= 0){
                HttpContext.Session.SetString("action", "YOU LOSE!!");
                ViewBag.win = "YOU LOSE!!!!!";
            }
            ViewBag.feed = HttpContext.Session.GetInt32("feed");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.action = HttpContext.Session.GetString("action");
            return View("winlose");
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult reset(){
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }

    }

}