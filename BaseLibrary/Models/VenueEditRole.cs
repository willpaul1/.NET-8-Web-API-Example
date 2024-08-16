using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class VenueEditRole
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; } = new Venue();

        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int RoleId { get; set; }
        public SystemRole? Role { get; set; }
    }
}
