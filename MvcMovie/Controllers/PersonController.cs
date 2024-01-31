using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class PersonldController : Controller
    { 
        // GET: /person/
        public IActionResult A()
        {
            return View();
        } 
        // GET: /Person/B/ 

        public string B()
        {
            return "This is the Welcome action method...";
        }
    
    }
}
