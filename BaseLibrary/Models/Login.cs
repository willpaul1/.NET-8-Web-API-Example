namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class Login
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
