using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Features.Authorization;
using SP19.P05.Web.Features.Menus;

namespace SP19.P05.Web.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SP19.P05.Web.Features.Menus.Menu> Menu { get; set; }
        public DbSet<SP19.P05.Web.Features.Menus.MenuDto> MenuDto { get; set; }

        public DbSet<SP19.P05.Web.Features.LineItems.MenuItem> MenuItem { get; set; }


    }
}
