using LiveSchedule.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveSchedule.API.Services.Interfaces
{
    public interface ILiveScheduleService
    {
        Task<IEnumerable<LiveScheduleDto>> GetAll();

        Task<LiveScheduleDto> Get(int id);

        Task<(bool Success, LiveScheduleDto LiveSchedule)> Add(LiveScheduleDto liveSchedule);

        Task<bool> Update(int id, LiveScheduleDto liveSchedule);

        Task<bool> Delete(int id);
    }
}
