using System.Linq.Expressions;
using DogoMeet.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DogoMeet.Common.Repository;

/// <summary>
/// Provides a base implementation of the <see cref="IGenericRepository{T}"/> interface for managing entities.
/// </summary>
/// <typeparam name="TModel">The type of entity managed by this repository.</typeparam>
public class GenericRepository<TModel>(DbContext context) : IGenericRepository<TModel>
    where TModel : ModelBase
{
    private readonly DbSet<TModel> _dbSet = context.Set<TModel>();

    /// <inheritdoc/>
    public async Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateAsync(TModel entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(TModel entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(id, cancellationToken);
        if (entity == null) return false;
        
        _dbSet.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}