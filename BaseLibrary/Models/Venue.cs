namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Address2 { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public int PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Website { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;


        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<VenueEditRole> VenueEditRoles { get; set; } = new List<VenueEditRole>();
    }
}
