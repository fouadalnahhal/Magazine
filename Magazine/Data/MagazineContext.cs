using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazine.Models;
using Microsoft.Extensions.Hosting;

namespace Magazine.Data
{
    public class MagazineContext : DbContext
    {
        public MagazineContext(DbContextOptions<MagazineContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MagazineSection>()
                .HasOne(p => p.MagazineHead)
                .WithMany(b => b.MagazineSections);

            modelBuilder.Entity<MagazineItem>()
                .HasOne(p => p.MagazineSection)
                .WithMany(b => b.MagazineItems);

            modelBuilder.Entity<MagazineItem>()
                .HasOne(p => p.MagazineHead)
                .WithMany(b => b.MagazineItems);

            modelBuilder.Entity<MagazineSlider>()
               .HasOne(p => p.MagazineHead)
               .WithMany(b => b.MagazineSliders);

            modelBuilder.Entity<MagazinePayment>()
               .HasOne(p => p.MagazineHead)
               .WithMany(b => b.MagazinePayments);

            modelBuilder.Entity<PurchaseOrderH>()
                .HasOne(h => h.Customer)
                .WithMany(c => c.PurchaseOrderHs);

            modelBuilder.Entity<PurchaseOrderD>()
                .HasOne(d => d.PurchaseOrderH)
                .WithMany(h => h.PurchaseOrderDs);
        }
        public DbSet<MagazineHead> MagazineHead { get; set; } = default!;
        public DbSet<MagazineSection> MagazineSection { get; set; }
        public DbSet<MagazineItem> MagazineItems { get; set; }
        public DbSet<MagazinePayment> MagazinePayment { get; set; }
        public DbSet<MagazineSlider> MagazineSlider { get; set; }
        public DbSet<Magazine.Models.Customer> Customer { get; set; }
        public DbSet<Magazine.Models.PurchaseOrderD> PurchaseOrderD { get; set; }
        public DbSet<Magazine.Models.PurchaseOrderH> PurchaseOrderH { get; set; }
    }
}
