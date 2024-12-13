using System.ComponentModel.DataAnnotations;
using DogoMeet.Common;
using DogoMeet.Common.Models;

namespace DogoMeet.Data.Models;

public class User : ModelBase
{
    [Required]
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Username { get; set; }
    
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required, MinLength(1)]
    IEnumerable<Dog> Dogs { get; set; }
}