namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class LeadArtistsInfo
    {
        public int Id { get; set; }
        public string PerformerFullname { get; set; } = String.Empty;
        public string Designation { get; set; } = String.Empty;
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();

    }
}
