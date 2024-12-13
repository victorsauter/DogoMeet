using DogoMeet.Common.Models;

namespace DogoMeet.Models.User;

public class UserDto : DtoBase
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    IEnumerable<Dog.DogDto> dogs { get; set; }
}