using DogoMeet.Common.Models;
using DogoMeet.Models.Dog;

namespace DogoMeet.Models.Walk;

public class WalkCreateRequest : CreateRequestBase, IWalkRequest
{
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public IEnumerable<DogDto>? Dogs { get; set; }
}