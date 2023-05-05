using ClinicManagement.Common.Utilities;
using ClinicManagement.Constant;
using ClinicManagement.Data.DbContexts.Sql.SqlServer;
using ClinicManagement.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ClinicManagement.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext

    {
        protected readonly TContext DbContext;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
            //DbSet on Entity ro behmon mide  
        }
        #region Async Method

        public virtual async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await Entities.FindAsync(ids, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAllAsync(CancellationToken cancellationToken, bool saveNow = true)
        {
            var rows = await Entities.ToListAsync();
            Assert.NotNull(rows, nameof(rows), "لیست مورد نظر شما خالی است!");
            Entities.RemoveRange(rows);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Sync Methods

        public virtual IQueryable<TEntity> GetEntitiesQuery()
        {
            return Entities.AsQueryable();
        }

        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public virtual void Add(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.AddRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void DeleteAll(bool saveNow = true)
        {
            var rows = Entities.ToList();
            foreach (var row in rows)
                Entities.Remove(row);
            if (saveNow)
                DbContext.SaveChanges();
        }
        #endregion

        #region Attach & Detach
        public virtual void Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = DbContext.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;
        }

        public virtual void Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (DbContext.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);
        }
        #endregion

        #region Explicit Loading
        public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken)
            where TProperty : class
        {
            Attach(entity);

            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                await collection.LoadAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
            where TProperty : class
        {
            Attach(entity);
            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                collection.Load();
        }

        public virtual async Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                await reference.LoadAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                reference.Load();
        }
        #endregion
    }

    public class Repository<TEntity>
        : Repository<ApplicationDbContext, TEntity>,
          IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public Repository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override IQueryable<TEntity> Table => base.Table;

        public override IQueryable<TEntity> TableNoTracking => base.TableNoTracking;

        public override void Add(TEntity entity, bool saveNow = true)
        {
            base.Add(entity, saveNow);
        }

        public override Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.AddAsync(entity, cancellationToken, saveNow);
        }

        public override void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            base.AddRange(entities, saveNow);
        }

        public override Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.AddRangeAsync(entities, cancellationToken, saveNow);
        }

        public override void Attach(TEntity entity)
        {
            base.Attach(entity);
        }

        public override void Delete(TEntity entity, bool saveNow = true)
        {
            base.Delete(entity, saveNow);
        }

        public override void DeleteAll(bool saveNow = true)
        {
            base.DeleteAll(saveNow);
        }

        public override Task DeleteAllAsync(CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.DeleteAllAsync(cancellationToken, saveNow);
        }

        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.DeleteAsync(entity, cancellationToken, saveNow);
        }

        public override void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            base.DeleteRange(entities, saveNow);
        }

        public override Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.DeleteRangeAsync(entities, cancellationToken, saveNow);
        }

        public override void Detach(TEntity entity)
        {
            base.Detach(entity);
        }

        public override TEntity GetById(params object[] ids)
        {
            return base.GetById(ids);
        }

        public override Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return base.GetByIdAsync(cancellationToken, ids);
        }

        public override IQueryable<TEntity> GetEntitiesQuery()
        {
            return base.GetEntitiesQuery();
        }

        public override void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
        {
            base.LoadCollection(entity, collectionProperty);
        }

        public override Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken)
        {
            return base.LoadCollectionAsync(entity, collectionProperty, cancellationToken);
        }

        public override void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
        {
            base.LoadReference(entity, referenceProperty);
        }

        public override Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken)
        {
            return base.LoadReferenceAsync(entity, referenceProperty, cancellationToken);
        }

        public override void Update(TEntity entity, bool saveNow = true)
        {
            base.Update(entity, saveNow);
        }

        public override Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.UpdateAsync(entity, cancellationToken, saveNow);
        }

        public override void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            base.UpdateRange(entities, saveNow);
        }

        public override Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            return base.UpdateRangeAsync(entities, cancellationToken, saveNow);
        }
    }
}
