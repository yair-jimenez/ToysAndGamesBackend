using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class CompanyConfiguration: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Addres).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired(false);
            builder.Ignore(p => p.Product);
            builder.HasData(new Company[1] {
                new Company()
                {
                    Id=1,
                    Name = "Mattel",
                    Addres = "",
                    LastModification = DateTime.Now
                }
            });
           
        }
    }
}
