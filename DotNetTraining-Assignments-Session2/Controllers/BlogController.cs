using DotNetTraining_Assignments_Session2.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTraining_Assignments_Session2.Controllers
{
    public class BlogController : Controller
    {
        private readonly IConfiguration _config;
        public BlogController(IConfiguration config)
        {
            _config = config;

        }
        
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            var person = new Person()
            {
                Id = 1,
                Name = "Rakesh Lad",
                Age = 37
            };

            var section = _config.GetSection("Logging:LogLevel");
            var value = section.GetValue<string>("Default");
           
            person.Name= value;

            return View(person);
        }
    }
}
