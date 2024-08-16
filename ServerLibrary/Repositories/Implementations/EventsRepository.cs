using BaseLibrary.DTOs;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using BaseLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using BaseLibrary.Models;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Implementations
{
    public class ProductionsRepository(AppDbContext appDbContext) : IEvents
    {
        public async Task<List<EventDto>> GetAllEvents(QueryObject query)
        {
            //This is mostly a test fuction for ensuring PK and FK are linked correctly, it returns a very large object not advised to use in production.
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var events = await appDbContext.Events
                .Include(ev => ev.Venue)
                .Include(ev => ev.IndividualEventDateTimes)
                .Include(ev => ev.LeadArtistsInfos)
                .Include(ev => ev.AdditionalImages)
                .Include(ev => ev.BackupArtistsInfos)
                .OrderBy(ev => ev.Id)
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();

            List<EventDto> eventDtos = new();
            foreach (var ev in events)
            {
                var productionDto = new EventDto
                {
                    Id = ev.Id,
                    Name = ev.Name,
                    Description = ev.Description,
                    MainImage = ev.MainImage,
                    CriticRating = ev.CriticRating,
                    AudienceRating = ev.AudienceRating,
                    Wishlisted = ev.Wishlisted,
                    Likes = ev.Likes,
                    LowestPrice = ev.LowestPrice,
                    HighestPrice = ev.HighestPrice,
                    TicketLink = ev.TicketLink,
                    Performer = ev.Performer,
                    Director = ev.Director,
                    Writer = ev.Writer,
                    Composer = ev.Composer,
                    Choreographer = ev.Choreographer,
                    CostumeDesigner = ev.CostumeDesigner,
                    SetDesigner = ev.SetDesigner,
                    SoundDesigner = ev.SoundDesigner,
                    LeadArtitstsDto = ev.LeadArtistsInfos.Select(m => new LeadArtistsInfoDto
                    {
                        PerformerFullname = m.PerformerFullname,
                        Designation = m.Designation
                    }).ToList(),
                    BackupArtistsDto = ev.BackupArtistsInfos.Select(e => new BackupArtistsInfoDto
                    {
                        Fullname = e.Fullname,
                        Designation = e.Designation
                    }).ToList(),
                    IndividualEventDateTimeDtos = ev.IndividualEventDateTimes.Select(i => new IndividualEventDateTimeDto
                    {
                        ProductionDate = i.ProductionDate,
                        ProductionTime = i.ProductionTime
                    }).ToList(),
                    AdditionalImages = ev.AdditionalImages.Select(a => new AdditionalImageDto
                    {
                        ImageUrl = a.ImageUrl
                    }).ToList(),

                    VenueDto = new VenueDto
                    {
                        Name = ev.Venue.Name,
                        Location = ev.Venue.Location,
                        Address = ev.Venue.Address,
                        Address2 = ev.Venue.Address2,
                        City = ev.Venue.City,
                        State = ev.Venue.State,
                        PostalCode = ev.Venue.PostalCode,
                        Latitude = ev.Venue.Latitude,
                        Longitude = ev.Venue.Longitude,
                        Description = ev.Venue.Description,
                        ImageUrl = ev.Venue.ImageUrl,
                        Website = ev.Venue.Website,
                        PhoneNumber = ev.Venue.PhoneNumber,
                        Email = ev.Venue.Email
                    }
                };

                eventDtos.Add(productionDto);
            }
            return eventDtos;
        }

        //Not implemented yet
        public async Task<EventDto> GetEventById(int id)
        {
            var production = await appDbContext.Events
                .Include(p => p.Venue)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (production == null)
            {
                return null;
            }

            return new EventDto
            {
                Id = production.Id,
                Name = production.Name,
                Description = production.Description,
                VenueDto = new VenueDto
                {
                    Name = production.Venue.Name,
                    Location = production.Venue.Location
                }
            };
        }
        //********************************************************************************

        public async Task<GeneralResponse> CreateEvent(CreateEventDto createEventDto)
        {

            // Null check needed
            if (createEventDto == null)
            {
                return new GeneralResponse(false, "Event was not created");
            }

            // Check if the VenueId exists
            var venue = await appDbContext.Venues.FindAsync(createEventDto.VenueId);
            if (venue == null)
            {
                return new GeneralResponse(false, "Venue not found");
            }

            var newEvent = new Event
            {
                VenueId = createEventDto.VenueId,
                Name = createEventDto.Name,
                Description = createEventDto.Description,
                MainImage = createEventDto.MainImage,
                CriticRating = createEventDto.CriticRating,
                AudienceRating = createEventDto.AudienceRating,
                Wishlisted = createEventDto.Wishlisted,
                Likes = createEventDto.Likes,
                LowestPrice = createEventDto.LowestPrice,
                HighestPrice = createEventDto.HighestPrice,
                TicketLink = createEventDto.TicketLink,
                Performer = createEventDto.Performer,
                Director = createEventDto.Director,
                Writer = createEventDto.Writer,
                Composer = createEventDto.Composer,
                Choreographer = createEventDto.Choreographer,
                CostumeDesigner = createEventDto.CostumeDesigner,
                SetDesigner = createEventDto.SetDesigner,
                SoundDesigner = createEventDto.SoundDesigner,
                AdditionalImages = createEventDto.AdditionalImages.Select(a => new AdditionalImage
                {
                    ImageUrl = a.ImageUrl
                }).ToList(),
                LeadArtistsInfos = createEventDto.LeadArtistsInfoDtos.Select(m => new LeadArtistsInfo
                {
                    PerformerFullname = m.PerformerFullname,
                    Designation = m.Designation
                }).ToList(),
                BackupArtistsInfos = createEventDto.BackupArtistsInfoDtos.Select(e => new BackupArtistsInfo
                {
                    Fullname = e.Fullname,
                    Designation = e.Designation
                }).ToList(),
                IndividualEventDateTimes = createEventDto.IndividualEventDateTimeDtos.Select(i => new IndividualEventDateTime
                {
                    ProductionDate = i.ProductionDate,
                    ProductionTime = i.ProductionTime
                }).ToList()
            };

            appDbContext.Events.Add(newEvent);
            await appDbContext.SaveChangesAsync();

            return new GeneralResponse(true, "Event created successfully");
        }
    


    

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = appDbContext.Add(model!);
            await appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}
