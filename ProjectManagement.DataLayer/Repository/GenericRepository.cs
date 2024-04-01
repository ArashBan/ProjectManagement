using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataLayer.Context;
using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ProjectManagementContext _context;

        public GenericRepository(ProjectManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeEntity(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await AddEntity(entity);
            }
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsDeleted = true;
            EditEntity(entity);
        }

        public async Task DeleteEntity(long id)
        {
            TEntity entity = await GetEntityById(id);
            if (entity != null) DeleteEntity(entity);
        }

        public void DeletePermanent(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeletePermanent(long id)
        {
            TEntity entity = await GetEntityById(id);
            if (entity != null) DeletePermanent(entity);
        }

        public void DeletePermanentEntities(List<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public void EditEntity(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TEntity> GetEntityById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null)
                await _context.DisposeAsync();
        }
    }
}
