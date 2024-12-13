using DogoMeet.Common;
using DogoMeet.Common.Models;

namespace DogoMeet.Data.Models;

public class Dog : ModelBase
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Breed { get; set; }
    
    public string Color { get; set; }
    
    public short Age { get; set; }
    
    public string Gender { get; set; }

    public string Description { get; set; }
    
    public User MainOwner { get; set; }
    
    public User SecondaryOwner { get; set; }
}