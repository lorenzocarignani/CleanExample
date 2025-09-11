using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
    public int Age { get; set; }

    [MaxLength(100)]
    public string Position { get; set; } = string.Empty;
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}