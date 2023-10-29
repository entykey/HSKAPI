namespace HSKAPI.Models.DAL
{
    using Models.DomainModels;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Models.DomainModels.UserAgent;

    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // must have this line first, else you will end up getting the error (The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating')
            base.OnModelCreating(modelBuilder);

            // User - LogLogin (1-n) (DeviceInfo as json field)
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(l => l.DeviceInfo)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<DeviceInfo>(v)
                    );
            });

            modelBuilder.Entity<LogLogin>(entity =>
            {
                entity.Property(l => l.DeviceInfo)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<DeviceInfo>(v)
                    );
            });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.GetTableName().StartsWith("AspNet"))
                {
                    entityType.SetTableName(entityType.GetTableName().Substring(6)); // remove first 6 character
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LogLogin> LogLogins { get; set; }
        public DbSet<LienHe> LienHe { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
