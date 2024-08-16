namespace BaseLibrary.Models
{
    //IMPORTANT: In Production NULL vaules should not be used, this is just an example. Proper data validation should be implemented.
    //For information please see README.md
    public class IndividualEventDateTime
    {
        public int Id { get; set; }
        public DateOnly ProductionDate { get; set; }
        public TimeOnly ProductionTime { get; set; }
        public int EventId { get; set; }
        //navigation property
        public Event Event { get; set; } = new Event();

        //optional fields
        public bool IsCancelled { get; set; } = false;
        public bool IsExemption { get; set; } = false;

    }
}
