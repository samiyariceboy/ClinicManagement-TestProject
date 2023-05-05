using MediatR;
using System.Reflection;
using ClinicManagement.Common;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Entities.Common;
using ClinicManagement.Common.Utilities;
using ClinicManagement.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot;
using ClinicManagement.Entities.Identity;
using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.Entities;
using Microsoft.AspNetCore.Identity;

namespace ClinicManagement.Data.DbContexts.Sql.SqlServer
{
    public class ApplicationDbContext : IdentityDbContext<UserAggregateRoot, Role, Guid, UserClaim, UserRole, IdentityUserLogin<Guid>, RoleClaim, UserToken>
    {
        private readonly IMediator _bus;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator bus)
           : base(options)
        {
            _bus = bus;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly entityAssembly = typeof(IEntity).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                conf => conf.IsClass && !conf.IsAbstract && conf.IsPublic);

            modelBuilder.RegisterAllEntities<IEntity>(entityAssembly);
            modelBuilder.RegisterEntityTypeConfiguration(entityAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }
        #region /// <summary>
        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            ValidationErrors();
            int affectedRows = await base.SaveChangesAsync(cancellationToken);
            if (affectedRows > 0)
            {
                await PublishEventsAsync(cancellationToken);
            }

            return affectedRows;
        }
        /// <summary>
        /// هر چیزی که قراره آپدیت و یا ادد بشه رو، قبلش ی و ک عربی و فارسی و اعداد انگلیسی فارسیشون رو درست میکنه 
        /// </summary>
        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
        #endregion


        #region Methods
        private void ValidationErrors()
        {
            var validationErrors = ChangeTracker
            .Entries<IValidatableObject>()
            .SelectMany(e => e.Entity.Validate(null))
            .Where(r => r != ValidationResult.Success);

            if (validationErrors.Any())
                throw new AppException(ApiResultStatusCode.LogicError, validationErrors.GetValidationResultErrors(), null);
        }


        private async Task PublishEventsAsync(CancellationToken cancellationToken)
        {
            var aggregateRoots =
                    ChangeTracker.Entries()
                    .Where(current => current.Entity is IAggregateRoot)
                    .Select(current => current.Entity as IAggregateRoot)
                    .ToList();

            foreach (var aggregateRoot in aggregateRoots)
            {
                foreach (var domainEvent in aggregateRoot.DomainEvents)
                    await _bus.Publish(domainEvent, cancellationToken);
                aggregateRoot.ClearDomainEvents();
            }
        }
        #endregion
    }
}
