using BaseLibrary.DTOs;
using BaseLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class VenuesRepository(AppDbContext appDbContext) : IVenues
    {
        public async Task<List<VenueWithEventsDto>> GetAllVenuesWithEvents(QueryObject query)
        {
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var venues = await appDbContext.Venues
                .Include(t => t.Events)
                .OrderBy(t => t.Id)
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();

            List<VenueWithEventsDto> venueWithEventsDtos = new();
            foreach (var venue in venues)
            {
                var venueWithProductions = new VenueWithEventsDto
                {
                    Name = venue.Name,
                    Location = venue.Location,
                    Address = venue.Address,
                    Address2 = venue.Address2,
                    City = venue.City,
                    State = venue.State,
                    PostalCode = venue.PostalCode,
                    Latitude = venue.Latitude,
                    Longitude = venue.Longitude,
                    Description = venue.Description,
                    ImageUrl = venue.ImageUrl,
                    Website = venue.Website,
                    PhoneNumber = venue.PhoneNumber,
                    Email = venue.Email,
                    LimitedEventDtos = venue.Events.Select(p => new LimitedEventDto
                    {
                        Name = p.Name,
                        MainImage = p.MainImage,
                        LowestPrice = p.LowestPrice
                    }).ToList()
                };

                venueWithEventsDtos.Add(venueWithProductions);
            }
            return venueWithEventsDtos;

        }
    }
}
