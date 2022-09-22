using DotNetTraining_Assignments_Session2.Model;
using DotNetTraining_Assignments_Session2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTraining_Assignments_Session2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IConfiguration _config;
        public PeopleController(IPeopleService peopleService, IConfiguration config)
        {
            _peopleService = peopleService;
            _config = config;
        }
        
        public ActionResult Index()
        {
            ViewData["Environment"] = _config.GetValue<string>("Environment");
            var data=_peopleService.GetAllPeoples();
            return View(data);
        }
        
        public ActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    person.Id = _peopleService.GetAllPeoples().Count + 1;
                    bool result = _peopleService.CreatePeople(person);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                
                return View();
            }
            catch
            {
                return View();
            }
        }
        
    }
}
