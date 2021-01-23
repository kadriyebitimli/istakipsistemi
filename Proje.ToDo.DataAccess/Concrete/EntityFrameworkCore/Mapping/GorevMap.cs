using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class GorevMap : IEntityTypeConfiguration<Gorev>
    {
        public void Configure(EntityTypeBuilder<Gorev> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Ad).HasMaxLength(200);
            builder.Property(I => I.Aciklama).HasColumnType("ntext");
            builder.HasOne(I => I.Aciliyet).WithMany(I => I.Gorevler).HasForeignKey(I => I.AciliyetId);
        }
    }
}
