using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class BackupArtistsInfoDto
    {
        public string Fullname { get; set; } = String.Empty;
        public string Designation { get; set; } = String.Empty;
    }
}
