namespace DogoMeet.Common.Models;

public class CreateRequestBase : IRequest
{
    public required string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}