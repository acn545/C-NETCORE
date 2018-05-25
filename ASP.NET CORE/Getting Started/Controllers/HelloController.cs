using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Getting_Started.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("{First_name}/{Last_name}/{age}/{Fav_Color}")]
        public JsonResult Index(string First_name, string Last_name, int age, string Fav_Color){
            var stuff = new {
                FirstName = First_name,
                LastName = Last_name,
                age = age,
                color = Fav_Color
            };
            return Json(stuff);
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View();
        }
    }
}
