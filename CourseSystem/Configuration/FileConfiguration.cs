using CourseSystem.Entities.AppDbContextEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSystem.Configuration
{
    public class FileConfiguration : IEntityTypeConfiguration<FileDetails>
    {
        public void Configure(EntityTypeBuilder<FileDetails> builder)
        {
            builder.Property(x => x.FileName).IsRequired()
                                        .HasMaxLength(200);

            builder.Property(x=>x.Extension).IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.User)
                   .WithMany(u => u.FileDetails);

        }
    }
}
