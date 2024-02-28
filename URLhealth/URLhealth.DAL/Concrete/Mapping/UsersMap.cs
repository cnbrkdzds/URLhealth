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
    internal class UsersMapPersonellerMap : IEntityTypeConfiguration<USERS>
    {
        public void Configure(EntityTypeBuilder<USERS> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.MAIL).HasMaxLength(100);
            builder.Property(a => a.MAIL).IsRequired(true);
            builder.HasIndex(a => a.MAIL).IsUnique();
            builder.ToTable("USERS");
            builder.HasData(new USERS
            {
                ID = 1,
                MAIL = "canberkdizdas@gmail.com",
            });
        }
    }
}
