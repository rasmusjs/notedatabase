using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

[JsonObject(MemberSerialization.OptIn)] // Ignore all the base attributes
[Table("Instruments")]
public class Instrument
{
    [Key] public int Id { get; set; }

    [Column("Name", TypeName = "varchar(128)")]
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Column("Description", TypeName = "varchar(1024)")]
    [JsonProperty("Description")]
    public string Description { get; set; } = string.Empty;

    [InverseProperty("Instruments")] public virtual List<OrchestralSet>? OrchestralSets { get; set; }
}