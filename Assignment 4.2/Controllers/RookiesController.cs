using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment4_2.Models;

namespace Assignment4_2.Controllers
{
    public class RookiesController : Controller
    {
        private static List<MembersModel> listMember = new List<MembersModel>
        {
            new MembersModel
            {
                FirstName = "Le",
                LastName = "Thanh Dat",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 5, 19),
                BirthPlace = "Nghe An",
                PhoneNumber = "0123456789",
                IsGraduated = false
            },

            new MembersModel
            {
                FirstName = "Tran",
                LastName = "Thuy Trang",
                Gender = "Female",
                DateOfBirth = new DateTime(1997, 9, 8),
                BirthPlace = "Ha Noi",
                PhoneNumber = "0123456789",
                IsGraduated = true
            },

            new MembersModel
            {
                FirstName = "Le",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 12, 1),
                BirthPlace = "Ha Noi",
                PhoneNumber = "0123456789",
                IsGraduated = false
            }
        };

        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(listMember);
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
                listMember.Add(person);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < listMember.Count)
            {
                var person = listMember[index];
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
                if (index >= 0 && index < listMember.Count)
                {
                    var person = listMember[index];
                    person.FirstName = model.FirstName;
                    person.LastName = model.LastName;
                    person.PhoneNumber = model.PhoneNumber;
                    person.BirthPlace = model.BirthPlace;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < listMember.Count)
            {
                listMember.RemoveAt(index);
            }
            return RedirectToAction("Index");
        }
    }
}