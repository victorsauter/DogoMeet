using System.Linq.Expressions;
using DogoMeet.Common.Models;

namespace DogoMeet.Common.Repository;

/// <summary>
/// Defines the base repository interface with CRUD operations for entities.
/// </summary>
public interface IGenericRepository<TModel> where TModel : ModelBase
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>The entity found or null if not found.</returns>
    Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entities of the specified type.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of all entities.</returns>
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds entities that match the specified predicate.
    /// </summary>
    /// <param name="predicate">The filter expression to apply when searching for entities.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of entities matching the predicate.</returns>
    Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new entity in the data store.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    Task CreateAsync(TModel entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity in the data store.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    Task UpdateAsync(TModel entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the delete operation.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}