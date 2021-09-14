using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.AgeRestriction).HasDefaultValue(0).HasPrecision(3);
            builder.Property(p => p.Price).IsRequired(true).HasPrecision(10, 2);
            builder.HasOne(p => p.Company).WithOne(p => p.Product).HasForeignKey<Product>(p => p.CompanyId);
            builder.Ignore(p => p.Image);
            builder.HasData(new Product[3]
            {
                new Product()
                {
                    Id=1,
                    Name="HotWheels Model 1",
                    CompanyId = 1,
                    Description="Racing Model 1991",
                    Price=10.50m,
                    UrlImage ="",
                    AgeRestriction=5,
                    LastModification = System.DateTime.Now

                },
                new Product()
                {
                    Id=2,
                    Name="HotWheels Model 2",
                    CompanyId = 1,
                    Description="Racing Model 1991",
                    Price=100.50m,
                    UrlImage ="",
                    AgeRestriction=3,
                    LastModification = System.DateTime.Now
                },
                new Product()
                {
                    Id=3,
                    Name="HotWheels Model 3",
                    CompanyId = 1,
                    Description="Racing Model 1992",
                    Price=69.50m,
                    UrlImage ="",
                    AgeRestriction=3,
                    LastModification = System.DateTime.Now
                }
            });
        }
    }
}
