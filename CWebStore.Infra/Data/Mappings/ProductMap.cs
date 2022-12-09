using CWebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWebStore.Infra.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.ProductName)
            .Property(x => x.Name)
            .HasColumnName("ProductName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Price)
            .Property(x => x.BuyValue)
            .HasColumnName("Cost")
            .HasColumnType("DECIMAL(18,2)")
            .HasPrecision(18, 2);

        builder.OwnsOne(x => x.Price)
            .Property(x => x.SellValue)
            .HasColumnName("Value")
            .HasColumnType("DECIMAL(18,2)")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.OwnsOne(x => x.Price)
            .Property(x => x.Percentage)
            .HasColumnName("Percentage")
            .HasColumnType("DECIMAL(18,2)")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.OwnsOne(x => x.StockAvailableStock)
            .Property(x => x.AvailableStock)
            .HasColumnName("StockAvailableStock")
            .HasColumnType("INT")
            .IsRequired();

        builder.OwnsOne(x => x.Description)
            .Property(x => x.DescriptionText)
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(160);

        builder.OwnsOne(x => x.Manufacturer)
            .Property(x => x.Name)
            .HasColumnName("Manufacturer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.OwnsOne(x => x.ImageFileName)
            .Property(x => x.Name)
            .HasColumnName("ImageFileName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.OwnsOne(x => x.ImageUrl)
            .Property(x => x.UrlStringProperty)
            .HasColumnName("ImageUrl")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2048);

        builder.HasMany(x => x.Categories)
            .WithMany(x => x.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductCategory",
                product => product
                    .HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .HasConstraintName("FK_ProductCategory_Product_CategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                category => category
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("SaleId")
                    .HasConstraintName("FK_ProductCategory_Category_ProductId")
                    .OnDelete(DeleteBehavior.Cascade));

        builder.Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.ProductName)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.Price)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.StockAvailableStock)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.Description)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.Manufacturer)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.ImageFileName)
            .Ignore(x => x.Notifications);
        
        builder.OwnsOne(x => x.ImageUrl)
            .Ignore(x => x.Notifications);
    }
}