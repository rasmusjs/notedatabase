using System.ComponentModel.DataAnnotations.Schema;
using lars_notedatabase.Models;

public class ContributorRole
{
    public int Id { get; set; }

    [ForeignKey("ContributorId")] public int ContributorId { get; set; }

    public virtual Contributor? Contributor { get; set; }
    [ForeignKey("OrchestralSetId")] public int OrchestralSetId { get; set; }
    /*public virtual OrchestralSet OrchestralSet { get; set; }*/

    public int Role { get; set; }

    public enum Roles
    {
        Composer,
        Conductor,
        Orchestrator,
        Instrumentalist,
    }
}