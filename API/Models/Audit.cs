using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class Audit
{
    public Audit()
    {
    }

    public Audit(string title, string description, DateTime startDate, int state, List<Schedule>? schedules, List<Person>? persons, List<PersonAudited>? personAudited, List<PersonAuditor>? personAuditors, CommentPage? commentPage)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        State = state;
        Schedules = schedules;
        Persons = persons;
        PersonAudited = personAudited;
        PersonAuditors = personAuditors;
        CommentPage = commentPage;
    }

    public Guid Id { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public int State { get; set; }

    public List<Schedule>? Schedules { get; set; } = new List<Schedule>();
    [JsonIgnore] public List<Person>? Persons { get; set; } = new List<Person>();
    public List<PersonAudited>? PersonAudited { get; set; } = new List<PersonAudited>();
    public List<PersonAuditor>? PersonAuditors { get; set; } = new List<PersonAuditor>();
    public CommentPage? CommentPage { get; set; }
}