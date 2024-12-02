using System.ComponentModel.DataAnnotations;

namespace DogoMeet.EF;

public class User
{
    [Required]
    public Guid Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Username { get; set; }
    
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required, MinLength(1)]
    IEnumerable<Dog> dogs { get; set; }
}