using System.Collections.Generic;
using System.Threading.Tasks;
using Models = LiveSchedule.API.Domains.Models;

namespace LiveSchedule.API.Domains.Interfaces
{
    public interface ILiveSchedule
    {
        Task<IEnumerable<Models.LiveSchedule>> GetAll();

        Task<Models.LiveSchedule> Get(int id, bool noTracking = true);

        Task<bool> Add(Models.LiveSchedule liveSchedule);

        Task<bool> Update(Models.LiveSchedule liveSchedule);

        Task<bool> Delete(Models.LiveSchedule liveSchedule);
    }
}
