using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

[Table("Orchestral_sets")]
public class OrchestralSet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name", TypeName = "varchar(100)")]
    [Required]
    public string Name { get; set; }

    [Column("Description", TypeName = "varchar(1024)")]
    public string Description { get; set; }


    [Column("Created_date", TypeName = "date")]
    [Required]
    public DateTime CreatedDate { get; set; }

    [Column("Updated_date", TypeName = "date")]
    public DateTime UpdatedDate { get; set; }

    public int CountryId { get; set; }
    public virtual Country? Country { get; set; }

    [NotMapped] public List<int>? ContributorsId { get; set; }

    public virtual List<ContributorRole>? Contributors { get; set; }

    [JsonProperty("InstrumentsId")]
    [NotMapped]
    public List<int>? InstrumentsId { get; set; }

    [ForeignKey("InstrumentId")] public virtual List<Instrument>? Instruments { get; set; }

    public virtual List<Link>? Links { get; set; }

    [JsonProperty("Links")] [NotMapped] public virtual List<String>? LinkTransfer { get; set; } // TODO make this cleaner


    [NotMapped] public List<int>? FilesId { get; set; }

    public virtual List<FileAttachment>? Files { get; set; }
}