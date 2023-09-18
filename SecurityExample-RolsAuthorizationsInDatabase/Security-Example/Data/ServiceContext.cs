using Entities.Entities;
using Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<UserRolItem> UserRols { get; set; }
        public DbSet<AuthorizationItem> UserAuthorizations { get; set; }
        public DbSet<RolAuthorization> RolsAuthorizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserItem>(user =>
            {
                user.ToTable("t_users");
                user.HasOne<UserRolItem>().WithMany().HasForeignKey(u => u.IdRol);
            });

            builder.Entity<UserRolItem>(user =>
            {
                user.ToTable("t_user_rols");
            });

            builder.Entity<AuthorizationItem>(user =>
            {
                user.ToTable("t_endpoint_authorizations");
            });

            builder.Entity<RolAuthorization>(user =>
            {
                user.ToTable("t_rols_authorizations");
                user.HasOne<UserRolItem>().WithMany().HasForeignKey(a => a.IdRol);
                user.HasOne<AuthorizationItem>().WithMany().HasForeignKey(a => a.IdAuthorization);
            });
        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}
