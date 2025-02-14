using TicketManager.Application.Interfaces;
using TicketManager.Domain.Interfaces;

namespace Application.Services
{
    public abstract class BaseService<TEntity, TDto>(IBaseRepository<TEntity> repository) : IBaseService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IBaseRepository<TEntity> _repository = repository;

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return MapToDtoList(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return MapToDto(entity);
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);

            MapToEntity(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract void MapToEntity(TDto dto, TEntity entity);
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract IEnumerable<TDto> MapToDtoList(IEnumerable<TEntity> entities);
    }
}