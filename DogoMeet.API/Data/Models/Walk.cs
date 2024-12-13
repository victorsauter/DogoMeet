using DogoMeet.Common;
using DogoMeet.Common.Models;

namespace DogoMeet.Data.Models;

public class Walk : ModelBase
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<Dog> Dogs { get; set; }
}