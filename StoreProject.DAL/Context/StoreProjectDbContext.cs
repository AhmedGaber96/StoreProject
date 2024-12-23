using Microsoft.EntityFrameworkCore;
using StoreProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.DAL.Context
{
    public class StoreProjectDbContext :DbContext
    {
        public StoreProjectDbContext(DbContextOptions<StoreProjectDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreItem>()
                .HasKey(si => new { si.StoreId, si.ItemId }); 

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Store)
                .WithMany(s => s.StoreItems)
                .HasForeignKey(si => si.StoreId);

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.StoreItems)
                .HasForeignKey(si => si.ItemId);
        }
        public DbSet<Store> Store { get; set; }    
        public DbSet<Item> Item { get; set; }

        public  DbSet<StoreItem> storeItem { get; set; }
    }
}
