using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class CreateEventDto
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string MainImage { get; set; } = String.Empty;
        public ICollection<AdditionalImageDto> AdditionalImages { get; set; } = new List<AdditionalImageDto>();
        public int CriticRating { get; set; } = 1;
        public int AudienceRating { get; set; } = 1;
        public int Wishlisted { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public double LowestPrice { get; set; } = 0;
        public double HighestPrice { get; set; } = 0;
        public string TicketLink { get; set; } = String.Empty;
        public int VenueId { get; set; }
        public string Performer { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public string Composer { get; set; } = String.Empty;
        public string Choreographer { get; set; } = String.Empty;
        public string CostumeDesigner { get; set; } = String.Empty;
        public string SetDesigner { get; set; } = String.Empty;
        public string SoundDesigner { get; set; } = String.Empty;
        public ICollection<LeadArtistsInfoDto> LeadArtistsInfoDtos { get; set; } = new List<LeadArtistsInfoDto>();
        public ICollection<BackupArtistsInfoDto> BackupArtistsInfoDtos { get; set; } = new List<BackupArtistsInfoDto>();
        public ICollection<IndividualEventDateTimeDto> IndividualEventDateTimeDtos { get; set; } = new List<IndividualEventDateTimeDto>();
    }
}
