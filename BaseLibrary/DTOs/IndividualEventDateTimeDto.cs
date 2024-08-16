using BaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class IndividualEventDateTimeDto
    {
        
        public DateOnly ProductionDate { get; set; }
        public TimeOnly ProductionTime { get; set; }

        //optional fields
        public bool IsCancelled { get; set; } = false;
        public bool IsExemption { get; set; } = false;
    }
}
