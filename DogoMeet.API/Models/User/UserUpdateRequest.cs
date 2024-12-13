using DogoMeet.Common.Models;
using DogoMeet.Models.Dog;

namespace DogoMeet.Models.User;

public class UserUpdateRequest : UpdateRequestBase, IUserRequest
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IEnumerable<DogDto> dogs { get; set; }
}