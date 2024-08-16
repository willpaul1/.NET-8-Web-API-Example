using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<IndividualEventDateTime> IndividualEventDateTimes { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
        public DbSet<LeadArtistsInfo> LeadArtistsInfos { get; set; }
        public DbSet<AdditionalImage> AdditionalImages { get; set; }
        public DbSet<BackupArtistsInfo> BackupArtistsInfos { get; set; }
        public DbSet<VenueEditRole> VenueEditRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //one-to-many relationship between Venue and Event
            modelBuilder.Entity<Event>()
                .HasOne(ev => ev.Venue)
                .WithMany(venue => venue.Events)
                .HasForeignKey(ev => ev.VenueId);

            //one-to-many relationship between Event and IndividualEventDateTime
            modelBuilder.Entity<IndividualEventDateTime>()
                .HasOne(iedt => iedt.Event)
                .WithMany(ev => ev.IndividualEventDateTimes)
                .HasForeignKey(iedt => iedt.EventId);

            //one-to-many relationship between Event and AdditionalImage
            modelBuilder.Entity<AdditionalImage>()
                .HasOne(ai => ai.Event)
                .WithMany(ev => ev.AdditionalImages)
                .HasForeignKey(ai => ai.EventId);

            //one-to-many relationship between Event and LeadArtistsInfo
            modelBuilder.Entity<LeadArtistsInfo>()
                .HasOne(lai => lai.Event)
                .WithMany(ev => ev.LeadArtistsInfos)
                .HasForeignKey(lai => lai.EventId);

            //one-to-many relationship between Event and BackupArtistsInfo
            modelBuilder.Entity<BackupArtistsInfo>()
                .HasOne(bai => bai.Event)
                .WithMany(ev => ev.BackupArtistsInfos)
                .HasForeignKey(bai => bai.EventId);

            //many-to-many relationship between ApplicationUser and SystemRole
            modelBuilder.Entity<VenueEditRole>()
                .HasKey(ver => new { ver.VenueId, ver.UserId, ver.RoleId });

            //one-to-many relationship between Venue and VenueEditRole
            modelBuilder.Entity<VenueEditRole>()
                .HasOne(ver => ver.Venue)
                .WithMany(venue => venue.VenueEditRoles)
                .HasForeignKey(ver => ver.VenueId);

            //one-to-many relationship between ApplicationUser and VenueEditRole
            modelBuilder.Entity<VenueEditRole>()
                .HasOne(ver => ver.User)
                .WithMany(user => user.VenueEditRoles)
                .HasForeignKey(ver => ver.UserId);

            //one-to-many relationship between SystemRole and VenueEditRole
            modelBuilder.Entity<VenueEditRole>()
                .HasOne(ver => ver.Role)
                .WithMany()
                .HasForeignKey(ver => ver.RoleId);
        }

    }
}