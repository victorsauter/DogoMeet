using DogoMeet.Common.Models;

namespace DogoMeet.Common.Service;

/// <summary>
/// Represents a service for generic CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="TDto">The type of entity managed by this service.</typeparam>
/// <typeparam name="TUpdateRequest">The type of the request model used for updating entities.</typeparam>
/// <typeparam name="TCreateRequest">The type of the request model used for creating entities.</typeparam>
/// <typeparam name="TModel">The type of the data model used in the repository.</typeparam>
public interface IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel> 
    where TDto : DtoBase 
    where TCreateRequest : CreateRequestBase 
    where TUpdateRequest : UpdateRequestBase
    where TModel : ModelBase
{
    /// <summary>
    /// Retrieves an entity of type <typeparamref name="T"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation, with the entity of type <typeparamref name="T"/> as the result.</returns>
    Task<TDto> GetAsync(Guid id);
    
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with an <see cref="IEnumerable{T}"/> of entities as the result.</returns>
    Task<IEnumerable<TDto>> GetAllAsync();
    
    /// <summary>
    /// Creates a new entity of type <typeparamref name="T"/> based on the provided request data.
    /// </summary>
    /// <param name="request">The data for creating the new entity.</param>
    /// <returns>A task representing the asynchronous operation, with the created entity of type <typeparamref name="T"/> as the result.</returns>
    Task CreateAsync(TCreateRequest request);
    
    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> based on the provided request data.
    /// </summary>
    /// <param name="request">The data for updating the entity.</param>
    /// <returns>A task representing the asynchronous operation, with the updated entity of type <typeparamref name="T"/> as the result.</returns>
    Task UpdateAsync(TUpdateRequest request);
    
    /// <summary>
    /// Deletes an existing entity of type <typeparamref name="T"/> based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, with the deleted entity of type <typeparamref name="T"/> as the result.</returns>
    Task DeleteAsync(Guid id);
}
