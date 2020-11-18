using Microsoft.EntityFrameworkCore;
using Models = LiveSchedule.API.Domains.Models;

namespace LiveSchedule.API.Repositories.Context
{
    public class LiveScheduleContext : DbContext
    {
        public LiveScheduleContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Models.LiveSchedule> LiveSchedules { get; set; }
    }
}
