namespace lars_notedatabase.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Files")]
public class FileAttachment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Orchestral_set_id")] public int OrchestralSetId { get; set; }

    public virtual OrchestralSet OrchestralSet { get; set; }

    [Column("File_path", TypeName = "VARCHAR(255)")]
    public string FilePath { get; set; }

    [Column("Upload_date", TypeName = "TIMESTAMP")]
    [Required]
    public DateTime UploadDate { get; set; }

    [Column("Actual_name", TypeName = "VARCHAR(255)")]
    public string ActualName { get; set; }
}