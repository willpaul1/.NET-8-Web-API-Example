using BaseLibrary.DTOs;
using BaseLibrary.Helpers;
using BaseLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IEvents
    {
        Task<List<EventDto>> GetAllEvents(QueryObject query);

        Task<EventDto> GetEventById(int id);

        Task<GeneralResponse> CreateEvent(CreateEventDto createEventDto);
    }
}
