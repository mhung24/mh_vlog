
using Mhung.Core.Domain.Content;
using Mhung.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unit1_Core.Domain.Content;

namespace Mhung.Data
{
    public class MhungBlogContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public MhungBlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostActivityLog> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostActivityLog> PostActivityLogs { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<PostInSeries> PostInSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => new {  x.UserId });
        }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

        //    foreach (var engtityEntry in entries)
        //    {
        //        var dateCreatedProp = engtityEntry.Entity.GetType().GetProperty("DateCreated");
        //        if (engtityEntry.State == EntityState.Added && dateCreatedProp != null)
        //        {
        //            dateCreatedProp.SetValue(engtityEntry.Entity, DateTime.Now);
        //        }

        //        //var modifiedDateProp = engtityEntry.Entity.GetType().GetProperty("ModifiedDate");
        //        //if (engtityEntry.State == EntityState.Modified && modifiedDateProp != null)
        //        //{
        //        //    modifiedDateProp.SetValue(engtityEntry.Entity, DateTime.Now);
        //        //}


        //    }

        //    return base.SaveChangesAsync( cancellationToken);
        //}
    }
}
