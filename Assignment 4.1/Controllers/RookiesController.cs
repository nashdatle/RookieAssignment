using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment4_1.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Assignment4_1.Controllers
{
    [Route("NashTech/Rookies")]
    public class RookiesController : Controller
    {
        private static List<MembersModel> memberList = new List<MembersModel>
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

        [Route("Index")]

        public IActionResult Index()
        {
            return Json(memberList);
        }


        [Route("GetMaleMembers")]

        public IActionResult GetMaleMembers()
        {
            var data = memberList.Where(p => p.Gender == "Male");
            return Json(data);
        }
        
        [Route("GetOldestMembers")]

        public IActionResult GetOldestMembers()
        {
            var maxAge = memberList.Max(p => p.Age);
            var oldest = memberList.FirstOrDefault(p => p.Age == maxAge);
            return Json(oldest);
        }

        [Route("GetFullName")]

        public IActionResult GetFullName()
        {
            var fullNames = memberList.Select(p => p.FullName);
            return Json(fullNames);
        }

        [Route("GetMembersByBirthYear")]

        public IActionResult GetMembersByBirthYear(int year, string comparator)
        {
            switch (comparator)
            {
                case "equal":
                    return Json(memberList.Where(p => p.DateOfBirth.Year == year));
                case "greater":
                    return Json(memberList.Where(p => p.DateOfBirth.Year > year));
                case "less":
                    return Json(memberList.Where(p => p.DateOfBirth.Year < year));
                default:
                    return Json(null);
            }
        }

        [Route("GetMembersByBirthYear/GetMembersBornIn2000")]

        public IActionResult GetMembersWhoBornIn2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "equals" });
        }

        [Route("GetMembersByBirthYear/GetMembersBornAfter2000")]

        public IActionResult GetMembersWhoBornAfter2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "greaterthan" });
        }

        [Route("GetMembersByBirthYear/GetMembersBornBefore2000")]

        public IActionResult GetMembersWhoBornBefore2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "lessthan" });
        }

    }
}