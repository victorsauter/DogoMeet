namespace DogoMeet.EF;

public class Walk
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<Dog> Dogs { get; set; }
}