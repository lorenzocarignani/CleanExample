

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Company
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    [Required , MaxLength(50)]
    public string Name { get; set; }

    [Required , MaxLength(200)]
    public string Address { get; set; }
    [Required , MaxLength(50)]
    public string Country { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}