using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.Entities;

namespace Task.DAL.Context
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options):base(options)
        {
            

        }

        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Siparis>()
                .HasMany(s => s.Uruns)
                .WithMany(s => s.Siparis)
                .UsingEntity<UrunSiparis>(
                "UrunSiparis",
                
                s =>  s.Property(d => d.Adet).HasDefaultValue(0) 
                );
            




        }


    }
}
