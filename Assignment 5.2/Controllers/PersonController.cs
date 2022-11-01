using Assignment_5_2.Models;
using Assignment_5_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_5_2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("")]
    public IEnumerable<PersonDetailsModel> GetAll()
    {
        var data = _personService.GetAll();
        return from item in data
                select new PersonDetailsModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    DateOfBirth = item.DateOfBirth,
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace
                };
    }

    [HttpGet("{index:int}")]
    public PersonDetailsModel? GetOne(Guid index)
    {
        var data = _personService.GetOne(index);
        if (data == null)
        {
            return null;
        }

        return new PersonDetailsModel
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Gender = data.Gender,
            DateOfBirth = data.DateOfBirth,
            PhoneNumber = data.PhoneNumber,
            BirthPlace = data.BirthPlace
        };
    }

    [HttpPost("")]
    public IActionResult Create(PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
                IsGraduated = false
            };
            var result = _personService.Create(person);

            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{index:int}")]
    public IActionResult Update(Guid index, PersonUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var data = _personService.GetOne(index);
            if(data == null)
            {
                return NotFound();
            }
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.PhoneNumber = model.PhoneNumber;
            data.BirthPlace = model.BirthPlace;

            var result = _personService.Update(index, data);
            return new JsonResult(result);
            
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{index:int}")]
    public IActionResult Delete(Guid index)
    {
        try
        {
            var data = _personService.GetOne(index);
            if(data == null)
            {
                return NotFound();
            }
            var result = _personService.Delete(index);
            return new JsonResult(result);
            
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
