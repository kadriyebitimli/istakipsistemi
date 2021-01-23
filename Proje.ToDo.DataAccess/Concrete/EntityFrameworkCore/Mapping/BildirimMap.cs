using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BildirimMap : IEntityTypeConfiguration<Bildirim>
    {
        public void Configure(EntityTypeBuilder<Bildirim> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Aciklama).HasColumnType("ntext").IsRequired();//gerekli alan
            builder.HasOne(I => I.AppUser).WithMany(I => I.Bildirimler).HasForeignKey(I => I.AppUserId);

        }
    }
}
