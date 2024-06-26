﻿using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Infrastructure.EfCoreServices.Intrefaces;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Core.Infrastructure.EfCoreServices.Crud
{
    public class EntityCrudService<TDbContext, TEntity, TKey1, TKey2, TKey3>
        : EntityCrudBaseService<TDbContext, TEntity>,
        IEntityCrudService<TEntity, TKey1, TKey2, TKey3>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey1, TKey2, TKey3>
        where TKey1 : IEquatable<TKey1>
        where TKey2 : IEquatable<TKey2>
        where TKey3 : IEquatable<TKey3>
    {
        #region Constructors

        public EntityCrudService(TDbContext dbContext) : base(dbContext) { }

        #endregion

        #region IEntityCrudService.Reading: Sync & Async 

        public virtual TEntity? Get(TKey1 key1, TKey2 key2, TKey3 key3, bool asNoTracking = true)
            => base.Get([key1, key2, key3], asNoTracking);

        public virtual TEntity? Get((TKey1, TKey2, TKey3) key, bool asNoTracking = true)
            => base.Get([key.Item1, key.Item2, key.Item3], asNoTracking);

        public virtual async Task<TEntity?> GetAsync(TKey1 key1, TKey2 key2, TKey3 key3, bool asNoTracking = true, CancellationToken cancellationToken = default)
            => await base.GetAsync([key1, key2, key3], asNoTracking, cancellationToken);

        public virtual async Task<TEntity?> GetAsync((TKey1, TKey2, TKey3) key, bool asNoTracking = true, CancellationToken cancellationToken = default)
            => await base.GetAsync([key.Item1, key.Item2, key.Item3], asNoTracking, cancellationToken);

        public virtual IEnumerable<TEntity> GetMany(IEnumerable<(TKey1, TKey2, TKey3)> keys, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(IEnumerable<(TKey1, TKey2, TKey3)> keys, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEntityCrudService.Updating: Sync & Async 

        public virtual TEntity Update((TKey1, TKey2, TKey3) key, Action<TEntity> updater, bool shouldSave = false)
            => base.Update([key.Item1, key.Item2, key.Item3], updater, shouldSave);

        public virtual async Task<TEntity> UpdateAsync((TKey1, TKey2, TKey3) key, Action<TEntity> updater, bool shouldSave = false, CancellationToken cancellationToken = default)
            => await base.UpdateAsync([key.Item1, key.Item2, key.Item3], updater, shouldSave, cancellationToken);

        public virtual void UpdateRange(IEnumerable<(TKey1, TKey2, TKey3)> keys, Action<TEntity> updater, bool shouldSave = false)
            => base.UpdateRange(ToArraysOfObjects(keys), updater, shouldSave);

        public virtual async Task UpdateRangeAsync(IEnumerable<(TKey1, TKey2, TKey3)> keys, Action<TEntity> updater, bool shouldSave = false, CancellationToken cancellationToken = default)
            => await base.UpdateRangeAsync(ToArraysOfObjects(keys), updater, shouldSave, cancellationToken);

        #endregion

        #region IEntityCrudService.Deleting: Sync & Async 

        public virtual void Delete(TKey1 key1, TKey2 key2, TKey3 key3, bool shouldSave = false)
            => base.Delete([key1, key2, key3], shouldSave);

        public virtual void Delete((TKey1, TKey2, TKey3) key, bool shouldSave = false)
            => base.Delete([key.Item1, key.Item2, key.Item3], shouldSave);

        public virtual async Task DeleteAsync(TKey1 key1, TKey2 key2, TKey3 key3, bool shouldSave = false, CancellationToken cancellationToken = default)
            => await base.DeleteAsync([key1, key2, key3], shouldSave, cancellationToken);

        public virtual async Task DeleteAsync((TKey1, TKey2, TKey3) key, bool shouldSave = false, CancellationToken cancellationToken = default)
            => await base.DeleteAsync([key.Item1, key.Item2, key.Item3], shouldSave, cancellationToken);

        public void DeleteRange(IEnumerable<(TKey1, TKey2, TKey3)> keys, bool shouldSave = false)
            => base.DeleteRange(ToArraysOfObjects(keys), shouldSave);

        public virtual async Task DeleteRangeAsync(IEnumerable<(TKey1, TKey2, TKey3)> keys, bool shouldSave = false, CancellationToken cancellationToken = default)
            => await base.DeleteRangeAsync(ToArraysOfObjects(keys), shouldSave, cancellationToken);

        #endregion
    }
}