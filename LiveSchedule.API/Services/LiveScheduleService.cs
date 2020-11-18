using AutoMapper;
using LiveSchedule.API.Domains.Interfaces;
using LiveSchedule.API.DTOs;
using LiveSchedule.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models = LiveSchedule.API.Domains.Models;

namespace LiveSchedule.API.Services
{
    public class LiveScheduleService : ILiveScheduleService
    {
        private readonly ILiveSchedule _repository;
        private readonly IMapper _mapper;

        public LiveScheduleService(ILiveSchedule repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiveScheduleDto>> GetAll()
        {
            var model = await _repository.GetAll();

            return _mapper.Map<IEnumerable<LiveScheduleDto>>(model);
        }

        public async Task<LiveScheduleDto> Get(int id)
        {
            var model = await _repository.Get(id);

            return _mapper.Map<LiveScheduleDto>(model);
        }

        public async Task<(bool Success, LiveScheduleDto LiveSchedule)> Add(LiveScheduleDto liveSchedule)
        {
            var model = _mapper.Map<Models.LiveSchedule>(liveSchedule);

            var success = await _repository.Add(model);

            return (success, _mapper.Map<LiveScheduleDto>(model));
        }

        public async Task<bool> Update(int id, LiveScheduleDto liveSchedule)
        {
            if (id != liveSchedule.Id)
            {
                return false;
            }

            var currentLiveSchedule = await _repository.Get(id);
            if (currentLiveSchedule == null)
            {
                return false;
            }

            var updateLiveSchedule = _mapper.Map(liveSchedule, currentLiveSchedule);

            return await _repository.Update(updateLiveSchedule);
        }

        public async Task<bool> Delete(int id)
        {
            var liveSchedule = await _repository.Get(id);
            if (liveSchedule == null)
            {
                return false;
            }

            return await _repository.Delete(liveSchedule);
        }
    }
}
