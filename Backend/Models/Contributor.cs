using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

[Table("Contributors")]
public class Contributor
{
    [Key] public int Id { get; set; }

    [Column("First_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; } = string.Empty;

    [Column("Last_name", TypeName = "varchar(50)")]
    public string LastName { get; set; } = string.Empty;

    [Column("Description", TypeName = "varchar(1024)")]
    public string Description { get; set; } = string.Empty;

    [ForeignKey("CountryId")] public int? CountryId { get; set; }
    public virtual Country? Country { get; set; }
    [Column("Birth_date")] public DateTime? BirthDate { get; set; }
    [Column("Death_date")] public DateTime? DeathDate { get; set; }
    [JsonIgnore] public virtual List<ContributorRole>? ContributorRoles { get; set; }
}