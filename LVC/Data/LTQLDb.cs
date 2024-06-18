using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LVC.Models;

    public class LTQLDb : DbContext
    {
        public LTQLDb (DbContextOptions<LTQLDb> options)
            : base(options)
        {
        }

        public DbSet<LVC.Models.LopHoc> LopHoc { get; set; } = default!;
        public DbSet<LVC.Models.SinhVien> SinhVien { get; set; } = default!;
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<LopHoc>()
           .HasMany(e=>e.SinhVien)
           .WithOne(p =>p.LopHoc)
           .HasForeignKey(p => p.MaLop)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
