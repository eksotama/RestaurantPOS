using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Cook
{
    public class CookConfiguration : IEntityTypeConfiguration<Cook>
    {
        public void Configure(EntityTypeBuilder<Cook> builder)
        {
        }
    }
}