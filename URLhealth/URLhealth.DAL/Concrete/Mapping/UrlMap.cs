using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Entities.Concrete;

namespace URLhealth.DAL.Concrete.Mapping
{
    public class UrlMap : IEntityTypeConfiguration<URL>
    {
        public void Configure(EntityTypeBuilder<URL> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.URL_LINK).HasMaxLength(250);
            builder.Property(a => a.URL_LINK).HasColumnType("Nvarchar(max)");
            builder.Property(a => a.URL_LINK).IsRequired(true);
            //builder.HasOne(a => a.Users)
            //    .WithMany(a => a.Url)
            //    .HasForeignKey(a => a.USER_ID)
            //    .HasConstraintName("FK_Url_Users");
            builder.ToTable("URL");
        }
    }
}
