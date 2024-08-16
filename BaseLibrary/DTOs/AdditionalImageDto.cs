using BaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class AdditionalImageDto
    {
        public string ImageUrl { get; set; } = String.Empty;
    }
}
