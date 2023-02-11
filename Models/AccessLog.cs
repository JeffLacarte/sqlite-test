using System.ComponentModel.DataAnnotations;

namespace sqlite_site.Models;

public class AccessLog
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime AccessedOn { get; set; }

}