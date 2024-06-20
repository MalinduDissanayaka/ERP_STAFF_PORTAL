
using ERP.TimeTableManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.TimeTableManagement.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<DaySlot> DaySlots { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<LectureHall> LectureHalls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Timetable entity
            modelBuilder.Entity<Timetable>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Timetable>()
                .HasMany(t => t.DaySlots)
                .WithOne(ds => ds.Timetable)
                .HasForeignKey(ds => ds.TimetableId);

            // Configure DaySlot entity
            modelBuilder.Entity<DaySlot>()
                .HasKey(ds => ds.Id);
            modelBuilder.Entity<DaySlot>()
                .HasMany(ds => ds.TimeSlots)
                .WithOne(ts => ts.DaySlot)
                .HasForeignKey(ts => ts.DaySlotId);

            // Configure TimeSlot entity
            modelBuilder.Entity<TimeSlot>()
                .HasKey(ts => ts.Id);
            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.Module)
                .WithMany(m => m.TimeSlots)
                .HasForeignKey(ts => ts.ModuleId);
            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.LectureHall)
                .WithMany(lh => lh.TimeSlots)
                .HasForeignKey(ts => ts.LectureHallId);
        }
    }
}