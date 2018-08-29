using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTest.Data
{
    public class IsoContext : DbContext
    {
        public IsoContext()
        {

        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleDay> ScheduleDays { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasKey<int>(s => s.ScheduleId);
            modelBuilder.Entity<ScheduleDay>().HasKey<int>(s => s.ScheduleDayId);//.HasRequired<Schedule>(s => s.Schedule).WithMany(s => s.ScheduleDays).HasForeignKey<int>(s => s.ScheduleDayId);
            modelBuilder.Entity<Employee>().HasKey<int>(s => s.PersonId);
            modelBuilder.Entity<User>().HasKey<int>(s => s.PersonId);
            //modelBuilder.Entity<Person>().HasKey<int>(s => s.PersonId);
        }
    }
}
