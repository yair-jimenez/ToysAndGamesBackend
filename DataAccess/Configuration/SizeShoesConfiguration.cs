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
    public class SizeShoesConfiguration : IEntityTypeConfiguration<SizeShoes>
    {
        public void Configure(EntityTypeBuilder<SizeShoes> builder) 
        {
            builder.HasKey(ck => new { ck.ProductId, ck.SizeId });
            builder.HasOne(sk => sk.Product).WithMany(pk => pk.SizeShoes).HasForeignKey(f => f.ProductId);
            builder.HasOne(sk => sk.Size).WithMany(pk => pk.SizeShoes).HasForeignKey(f => f.SizeId);
        }
    }
}
