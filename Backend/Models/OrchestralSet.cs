using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lars_notedatabase.Models;

[JsonObject(MemberSerialization.OptIn)] // Ignore all the base attributes
[Table("Orchestral_sets")]
public class OrchestralSet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonProperty("Id")]
    public int Id { get; set; }

    [Column("Name", TypeName = "varchar(100)")]
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Column("Description", TypeName = "varchar(1024)")]
    [JsonProperty("Description")]
    public required string Description { get; set; }


    [Column("Created_date", TypeName = "date")]
    [Required]
    [JsonProperty("CreatedDate")]

    public DateTime CreatedDate { get; set; }

    [Column("Updated_date", TypeName = "date")]
    [JsonProperty("UpdatedDate")]
    public DateTime UpdatedDate { get; set; }

    [Column("CountryId", TypeName = "int")]
    [JsonProperty("CountryId")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")] public virtual Country? Country { get; set; }

    [NotMapped] public List<int>? ContributorsId { get; set; }
    [JsonProperty("Contributors")] public virtual List<ContributorRole>? Contributors { get; set; }

    [JsonProperty("InstrumentsId")]
    [NotMapped] public List<int>? InstrumentsId { get; set; }

    [JsonProperty("Instruments")]
    [ForeignKey("InstrumentId")]
    public virtual List<Instrument>? Instruments { get; set; }

    public virtual List<Link>? Links { get; set; }

    [JsonProperty("Links")]
    [NotMapped]
    public virtual List<String>? LinkTransfer { get; set; } // TODO make this cleaner


    [NotMapped] public List<int>? FilesId { get; set; }

    public virtual List<FileAttachment>? Files { get; set; }
}