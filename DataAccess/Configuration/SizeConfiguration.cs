using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cat = Models;

namespace DataAccess.Configuration
{
    public class SizeConfiguration:IEntityTypeConfiguration<Cat.Size>
    {
        public void Configure(EntityTypeBuilder<Cat.Size> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ShoeSize).IsRequired();
            builder.Ignore(b => b.SizeShoes);
        }
    }
}
