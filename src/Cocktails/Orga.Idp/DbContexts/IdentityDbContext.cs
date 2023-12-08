using Microsoft.EntityFrameworkCore;
using Orga.Idp.Entities;

namespace Orga.Idp.DbContexts
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public IdentityDbContext(
          DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Subject)
            .IsUnique();

            modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                    Password = "password",
                    Subject = "ac46ef56-2155-4d0b-afd0-d10c5e7c89b1",
                    UserName = "Johnny",
                    Email = "johnny@emailprovider.com",
                    Active = true
                },
                new User()
                {
                    Id = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                    Password = "password",
                    Subject = "bcc4c51b-d20b-41dc-8152-cc7ed69c62c7",
                    UserName = "Linda",
                    Email = "linda@emailprovider.com",
                    Active = true
                });

            modelBuilder.Entity<UserClaim>().HasData(
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                 Type = "given_name",
                 Value = "Johnny"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                 Type = "family_name",
                 Value = "Oldman"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                 Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                 Value = "11/06/2003"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                 Type = "role",
                 Value = "admin"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                 Type = "country",
                 Value = "pt"
             },
             
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                 Type = "given_name",
                 Value = "Linda"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                 Type = "family_name",
                 Value = "Young"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                 Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                 Value = "11/06/2013"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                 Type = "role",
                 Value = "user"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                 Type = "country",
                 Value = "nl"
             });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // get updated entries
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .OfType<IConcurrencyAware>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
