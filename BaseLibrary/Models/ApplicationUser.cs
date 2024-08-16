namespace BaseLibrary.Models
{
    public class ApplicationUser
    {
        //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
        //For information please see README.md
        public int Id { get; set; }
        public string Fullname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public ICollection<VenueEditRole> VenueEditRoles { get; set; } = new List<VenueEditRole>();
    }
}
