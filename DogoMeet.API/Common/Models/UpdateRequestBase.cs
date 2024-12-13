namespace DogoMeet.Common.Models;

public class UpdateRequestBase : IRequest
{
    public Guid Id { get; set; }
    public required string UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}