using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entity;

namespace School.Infra.Configuration
{
    public class CourseConfiguration: IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DescriptionSubject).IsRequired();
            builder.Property(x => x.InitialDate).IsRequired();
            builder.Property(x => x.FinalDate).IsRequired();

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(y => y.CategoryId).IsRequired();
        }
    }
}
