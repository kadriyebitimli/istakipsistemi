using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
   public class TodoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-316LTSJE;database =Proje; integrated security = true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           
            modelbuilder.ApplyConfiguration(new GorevMap());
            modelbuilder.ApplyConfiguration(new AciliyetMap());
            modelbuilder.ApplyConfiguration(new RaporMap());
            modelbuilder.ApplyConfiguration(new AppUserMap());

          
            base.OnModelCreating(modelbuilder);
        }
       
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Aciliyet> Aciliyetler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }

        }
    }
