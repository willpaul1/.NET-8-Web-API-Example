namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string MainImage { get; set; } = String.Empty;
        public ICollection<AdditionalImage> AdditionalImages { get; set; } = new List<AdditionalImage>();
        public int CriticRating { get; set; }
        public int AudienceRating { get; set; }
        public int Wishlisted { get; set; }
        public int Likes { get; set; }
        public double LowestPrice { get; set; }
        public double HighestPrice { get; set; }
        public string TicketLink { get; set; } = String.Empty;

        // Foreign key
        public int VenueId { get; set; }

        // Navigation property
        public Venue Venue { get; set; } = new Venue();

        //optional fields

        public string Performer { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public string Composer { get; set; } = String.Empty;
        public string Choreographer { get; set; } = String.Empty;
        public string CostumeDesigner { get; set; } = String.Empty;
        public string SetDesigner { get; set; } = String.Empty;
        public string SoundDesigner { get; set; } = String.Empty;
        public ICollection<LeadArtistsInfo> LeadArtistsInfos { get; set; } = new List<LeadArtistsInfo>();
        public ICollection<BackupArtistsInfo> BackupArtistsInfos { get; set; } = new List<BackupArtistsInfo>();

        public ICollection<IndividualEventDateTime> IndividualEventDateTimes { get; set; } = new List<IndividualEventDateTime>();

    }
}
