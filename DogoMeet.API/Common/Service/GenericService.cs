using AutoMapper;
using DogoMeet.Common.Models;
using DogoMeet.Common.Repository;

namespace DogoMeet.Common.Service;

/// <summary>
/// Provides a general implementation for CRUD operations with an entity, allowing mapping between Data Transfer Objects (DTOs),
/// request models for create and update operations, and the underlying database models.
/// </summary>
/// <typeparam name="TDto">The type representing the DTO for the entity.</typeparam>
/// <typeparam name="TCreateRequest">The type representing the create request model.</typeparam>
/// <typeparam name="TUpdateRequest">The type representing the update request model.</typeparam>
/// <typeparam name="TModel">The type representing the database model for the entity.</typeparam>
public class GenericService<TDto, TCreateRequest, TUpdateRequest, TModel>(
    IGenericRepository<TModel> repository,
    IMapper mapper)
    : IGenericService<TDto, TCreateRequest, TUpdateRequest, TModel>
    where TDto : DtoBase
    where TCreateRequest : CreateRequestBase
    where TUpdateRequest : UpdateRequestBase
    where TModel : ModelBase
{
    /// <inheritdoc/>
    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var models = await repository.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<TDto>>(models);
        return dtos;
    }

    /// <inheritdoc/>
    public async Task<TDto> GetAsync(Guid id)
    {
        var model = await repository.GetAsync(id);
        var dto = mapper.Map<TDto>(model);
        return dto;
    }

    /// <inheritdoc/>
    public async Task CreateAsync(TCreateRequest request)
    {
        var model = mapper.Map<TModel>(request);
        await repository.CreateAsync(model);
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(TUpdateRequest request)
    {
        var model = mapper.Map<TModel>(request);
        await repository.UpdateAsync(model);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}