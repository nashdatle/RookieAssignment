using Microsoft.AspNetCore.Mvc;
using Assignment4_3.Models;
using Assignment4_3.Services;

namespace Assignment4_3.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;

        private readonly IPersonService _personService;

        public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            var models = _personService.GetAll();
            return View(models);
        }

        public IActionResult Detail(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                var model = new MembersDetailModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };
                ViewData["Index"] = index; 
                return View(model);
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MembersCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new MembersModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    BirthPlace = model.BirthPlace,
                    PhoneNumber = model.PhoneNumber,
                    IsGraduated = false
                };
                _personService.Create(person);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                var model = new MembersUpdateModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };
                ViewData["Index"] = index; 
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int index, MembersUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var person = _personService.GetOne(index);

                if (person != null)
                {
                    person.FirstName = model.FirstName;
                    person.LastName = model.LastName;
                    person.PhoneNumber = model.PhoneNumber;
                    person.BirthPlace = model.BirthPlace;

                    _personService.Update(index, person);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            var result = _personService.Delete(index);
            if (result == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAndRedirectToResultView(int index)
        {
            var result = _personService.Delete(index);
            if (result == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("DeletePersonName", result.FullName);
            return View("DeleteResult");
        }

        public IActionResult DeleteResult()
        {
            return View();
        }
    }
}