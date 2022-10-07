using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class PersonService
{
    private readonly DataContext _context;

    public PersonService(DataContext context)
    {
        _context = context;
    }

    public async Task<Person> CreatePersonAsync(Person newPerson)
    {
        _context.Persons.Add(newPerson);
        await _context.SaveChangesAsync();

        return newPerson;
    }

    public async Task<List<Person>> GetPersonsAsync()
    {
        return await _context.Persons
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Person?> GetPersonByIdAsync(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);

        return person;
    }
}