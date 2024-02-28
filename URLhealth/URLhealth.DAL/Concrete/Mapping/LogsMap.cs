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
    public class LogsMap : IEntityTypeConfiguration<LOGS>
    {
        public void Configure(EntityTypeBuilder<LOGS> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.LEVEL).HasMaxLength(50);
            builder.Property(a => a.LEVEL).IsRequired(true);
            builder.Property(a => a.URL).HasMaxLength(200);
            builder.Property(a => a.URL).IsRequired(true);
            builder.Property(a => a.MESSAGE).HasColumnType("Nvarchar(max)");
            builder.Property(a => a.MESSAGE).IsRequired(true);
            builder.ToTable("LOGS");
        }
    }
}
