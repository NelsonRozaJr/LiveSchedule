using LiveSchedule.API.Domains.Interfaces;
using LiveSchedule.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = LiveSchedule.API.Domains.Models;

namespace LiveSchedule.API.Repositories
{
    public class LiveScheduleRepository : ILiveSchedule
    {
        private readonly LiveScheduleContext _context;

        public LiveScheduleRepository(LiveScheduleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.LiveSchedule>> GetAll()
        {
            return await _context.LiveSchedules
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Models.LiveSchedule> Get(int id, bool noTracking = true)
        {
            IQueryable<Models.LiveSchedule> query;

            if (noTracking)
            {
                query = _context.LiveSchedules.AsNoTracking();
            }
            else
            {
                query = _context.LiveSchedules;
            }

            return await query
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Add(Models.LiveSchedule liveSchedule)
        {
            liveSchedule.RegistrationDate = DateTime.Now;
            _context.LiveSchedules.Add(liveSchedule);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> Update(Models.LiveSchedule liveSchedule)
        {
            liveSchedule.UpdateDate = DateTime.Now;
            _context.LiveSchedules.Update(liveSchedule);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> Delete(Models.LiveSchedule liveSchedule)
        {
            _context.LiveSchedules.Remove(liveSchedule);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
