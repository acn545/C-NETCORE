using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dojo_Survey{

    public class DojoController : Controller{
        [HttpGet]
        [Route("")]
        public ViewResult Index(){
            return View("Survey");
        }
        [HttpPost]
        [Route("results")]
        public IActionResult results(string name, string location, string favorite, string comment){
            ViewBag.name = name;
            ViewBag.loc = location;
            ViewBag.fav = favorite;
            ViewBag.com = comment;
            Console.WriteLine(ViewBag.name + ViewBag.loc + ViewBag.fav + ViewBag.com);
            return View("results");
        }
    }

}