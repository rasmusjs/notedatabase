using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lars_notedatabase.Models;

[Table("Countries")]
public class Country
{
    [Key] public int Id { get; set; }

    [Column("Name", TypeName = "varchar(100)")]
    [Required]
    public string Name { get; set; }
    
    // Navigation property for related OrchestralSets
    public virtual ICollection<OrchestralSet>? OrchestralSets { get; set; }
}