using DogoMeet.Common.Models;
using DogoMeet.Models.User;

namespace DogoMeet.Models.Dog;

public class DogDto : DtoBase
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Breed { get; set; }
    
    public string Color { get; set; }
    
    public short Age { get; set; }
    
    public string Gender { get; set; }

    public string Description { get; set; }
    
    public UserDto Owner { get; set; }
}