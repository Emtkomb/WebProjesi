﻿using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    { //IdentityDbContext<AppUser, AppRole, int>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-ACGE14T\\SQLEXPRESS;initial catalog=WebProg;integrated security=true");

        }
    

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>()
                .HasOne(d => d.Birim)
                .WithMany(p => p.Doktorlar)
                .HasForeignKey(d => d.BirimID);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Birim>()
                .HasOne(d => d.Hastane)
                .WithMany(p => p.Birimler)
                .HasForeignKey(d => d.HastaneID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Doktor)
                .WithMany(p => p.Randevular)
                .HasForeignKey(r => r.DoktorID);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.AppUser)
                .WithMany(p => p.Randevular)
                .HasForeignKey(r => r.AppUserId);
        }
    }
}