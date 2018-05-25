using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TimeDisplay.Controllers{

    public class TimeController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            //DateTime CurrentTime = DateTime.Now;
            return View("Time");
        }
    }

}