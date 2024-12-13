using DogoMeet.Common.Models;
using DogoMeet.Common.Service;

namespace DogoMeet.Common.Endpoint;

/// <summary>
/// Provides extension methods to map generic CRUD endpoints for a specified entity type and request type into a WebApplication's routing pipeline.
/// </summary>
public static class GenericEndpoints
{
    /// <summary>
    /// Maps CRUD endpoints for a specified DTO, create request, update request, and model type to the provided application instance.
    /// </summary>
    /// <typeparam name="TDto">The DTO type that represents the response model, derived from <see cref="DtoBase"/>.</typeparam>
    /// <typeparam name="TCreateRequest">The request type for creating entities, derived from <see cref="IRequestBase"/>.</typeparam>
    /// <typeparam name="TUpdateRequest">The request type for updating entities, derived from <see cref="IRequestBase"/>.</typeparam>
    /// <typeparam name="TModel">The model type that represents the data entity, derived from <see cref="ModelBase"/>.</typeparam>
    /// <param name="app">The web application instance to which the endpoints will be mapped.</param>
    /// <param name="groupName">The name of the group for the endpoints, used as part of the route and endpoint names.</param>
    public static void MapEndpoints<TDto, TCreateRequest, TUpdateRequest, TModel>(this WebApplication app,
        string groupName)
        where TDto : DtoBase
        where TCreateRequest : CreateRequestBase
        where TUpdateRequest : UpdateRequestBase
        where TModel : ModelBase
    {
        var group = app.MapGroup("/{groupName}");

        // GET
        group.MapGet("/", async (IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> genericService)
                => Results.Ok(await genericService.GetAllAsync()))
            .WithName($"GetAll{groupName}");

        // GET /{id}
        group.MapGet("/{id}", async (IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> genericService, Guid id)
                => Results.Ok(await genericService.GetAsync(id)))
            .WithName($"Get{groupName}");

        // POST
        group.MapPost("/", async (IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> genericService, TCreateRequest requestEntity)
                =>
            {
                await genericService.CreateAsync(requestEntity);
                return Results.Created($"/{groupName}", requestEntity);
            })
            .WithName($"Create{groupName}");

        // PUT
        group.MapPut("/", async (IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> genericService, TUpdateRequest requestEntity)
                =>
            {
                await genericService.UpdateAsync(requestEntity);
                return Results.Ok(requestEntity);
            })
            .WithName($"Update{groupName}");

        // DELETE
        group.MapDelete("/{id}", async (IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> genericService, Guid id)
                =>
            {
                await genericService.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName($"Delete{groupName}");
    }
}