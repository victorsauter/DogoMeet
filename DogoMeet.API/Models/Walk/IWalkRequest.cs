namespace DogoMeet.Models.Walk;

public interface IWalkRequest
{
    public string Title { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<Dog.DogDto>? Dogs { get; set; }
}