using System.Text.Json.Serialization;

namespace API.Models;

public class PersonAudited
{
    public Guid AuditId { get; set; }
    [JsonIgnore] public Audit Audit { get; set; }

    public Guid PersonId { get; set; }
    [JsonIgnore] public Person Person { get; set; }
}