using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

[Table("Instruments")]
public class Instrument
{
    [Key] public int Id { get; set; }

    [Column("Name", TypeName = "varchar(128)")]
    [Required]
    public string Name { get; set; }

    [Column("Description", TypeName = "varchar(1024)")]
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    [InverseProperty("Instruments")]
    public virtual List<OrchestralSet>? OrchestralSets { get; set; }
}