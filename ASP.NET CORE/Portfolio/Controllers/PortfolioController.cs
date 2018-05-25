using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller{

        [HttpGet]
        [Route("")]
        public ViewResult Index(){
        return View("Home");
        }

        [HttpGet]
        [Route("projects")]
        public ViewResult Projects(){
        return View("projects");
        }

        [HttpGet]
        [Route("Contact")]
        public ViewResult Contact(){
        return View("contact");
        }
        
        
    }
}