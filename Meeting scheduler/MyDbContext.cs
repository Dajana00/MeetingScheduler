using MeetingScheduler.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MeetingScheduler

{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<DayOff> DaysOff { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Leave>().ToTable("Leaves");
            modelBuilder.Entity<Vacation>().ToTable("Vacations");
            modelBuilder.Entity<DayOff>().ToTable("DaysOff");
            modelBuilder.Entity<SickLeave>().ToTable("SickLeaves");
            modelBuilder.Entity<SpecialEvent>().ToTable("SpecialEvents");
            modelBuilder.Entity<Meeting>().ToTable("Meetings");
        
            modelBuilder.Entity<MeetingUser>()
                .HasKey(mu => new { mu.MeetingId, mu.UserId });

            modelBuilder.Entity<MeetingUser>()
                .HasOne(mu => mu.Meeting)
                .WithMany(m => m.MeetingUsers)
                .HasForeignKey(mu => mu.MeetingId)
                .OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<MeetingUser>()
                .HasOne(mu => mu.User)
                .WithMany()
                .HasForeignKey(mu => mu.UserId)
                .OnDelete(DeleteBehavior.NoAction);  
        


    }
}
}
