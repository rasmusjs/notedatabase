using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

public class ContributorRole
{
    public int Id { get; set; }

    [JsonProperty("ContributorId")]
    [ForeignKey("ContributorId")]
    public int ContributorId { get; set; }

    public virtual Contributor? Contributor { get; set; }
    [ForeignKey("OrchestralSetId")] public int OrchestralSetId { get; set; }
    /*public virtual OrchestralSet OrchestralSet { get; set; }*/

    [JsonProperty("Role")] public int Role { get; set; }

    public enum Roles
    {
        Composer,
        Conductor,
        Orchestrator,
        Instrumentalist,
    }
}