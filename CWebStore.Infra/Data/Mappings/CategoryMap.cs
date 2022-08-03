using CWebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWebStore.Infra.Data.Mappings;

public class CategoryMap  : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.CategoryName)
            .Property(x => x.Name)
            .HasColumnName("CategoryName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();
            
        builder.OwnsOne(x => x.CategoryName)
            .Ignore(x => x.Notifications);
            
        builder.Ignore(x => x.Notifications);


    }
}
