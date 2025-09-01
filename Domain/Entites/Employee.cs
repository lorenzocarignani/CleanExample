using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    public string Position { get; set; }

    //Fk
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}