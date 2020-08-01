using Microsoft.EntityFrameworkCore;
using School.Domain.Entity;

namespace School.Infra.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder
                .Entity<CategoryEntity>()
                .HasData(new CategoryEntity(1, "Comportamental"),
                         new CategoryEntity(2, "Programação"),
                         new CategoryEntity(3, "Qualidade e Processos"));
        }
    }
}
