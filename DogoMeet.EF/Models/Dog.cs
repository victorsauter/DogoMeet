namespace DogoMeet.EF;

public class Dog
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Breed { get; set; }
    
    public string Color { get; set; }
    
    public short Age { get; set; }
    
    public string Gender { get; set; }

    public string Description { get; set; }
    
    public User Owner { get; set; }
}