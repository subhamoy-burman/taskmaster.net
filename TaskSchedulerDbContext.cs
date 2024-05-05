using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Worker
{
    public class Task_Sch
    {
        public int TaskID { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public string Command { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? PickedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? FailedAt { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? ReceiptHandle { get; set; }
    }
    public class TaskSchedulerDbContext : DbContext
    {
        public DbSet<Task_Sch> Tasks_Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task_Sch>().ToTable("Tasks_Schedules");
        }
    }
}
