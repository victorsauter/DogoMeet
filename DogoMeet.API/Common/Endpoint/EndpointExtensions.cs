using DogoMeet.Data.Models;
using DogoMeet.Models.Dog;
using DogoMeet.Models.User;
using DogoMeet.Models.Walk;

namespace DogoMeet.Common.Endpoint;

/// <summary>
/// Provides extension methods for mapping endpoints in a WebApplication instance.
/// </summary>
public static class EndpointExtensions
{
    /// <summary>
    /// Maps endpoint groups for various resources (e.g., user, walk, dog) to the WebApplication instance.
    /// </summary>
    /// <param name="app">The WebApplication instance to map the endpoints to.</param>
    public static void MapEndpoints(this WebApplication app)
    {
        // User
        app.MapEndpoints<UserDto, UserCreateRequest, UserUpdateRequest, User>("user");
        // Walk
        app.MapEndpoints<WalkDto, WalkCreateRequest, WalkUpdateRequest, Walk>("walk");
        // Dog
        app.MapEndpoints<DogDto, DogCreateRequest, DogUpdateRequest, Dog>("dog");
    }
}