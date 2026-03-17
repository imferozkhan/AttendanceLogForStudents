using AttendanceLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLog.Infrastructure.DBContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Role
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<Role>()
                .Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(100);

            // 🔹 User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 UserDetails (One-to-One)
            modelBuilder.Entity<UserDetails>()
                .HasKey(ud => ud.Id);

            modelBuilder.Entity<UserDetails>()
                .HasOne(ud => ud.User)
                .WithOne(u => u.UserDetails)
                .HasForeignKey<UserDetails>(ud => ud.UserId);

            // 🔹 Attendance (Student relation)
            modelBuilder.Entity<Attendance>()
                .HasKey(a => a.AttendanceId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.User)
                .WithMany(u => u.Attendances)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Attendance (RecordedBy relation - Faculty)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.RecordedUser)
                .WithMany(u => u.RecordedAttendances)
                .HasForeignKey(a => a.RecordedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
