using KASSS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KASSS.Data.Configuration
{
    public class ButtonConfiguration : IEntityTypeConfiguration<Button>
    {
        public void Configure(EntityTypeBuilder<Button> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Buttons");
        }
    }
}
