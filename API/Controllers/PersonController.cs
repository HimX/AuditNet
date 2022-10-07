using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _service;

    public PersonController(PersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Person>> CreatePerson(Person newPerson)
    {
        var person = await _service.CreatePersonAsync(newPerson);

        return CreatedAtAction(nameof(CreatePerson), new {id = person.Id}, person);
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetPersons()
    {
        var persons = await _service.GetPersonsAsync();

        return Ok(persons);
    }
}