using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class AdditionalImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
