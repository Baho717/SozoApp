namespace SozoApothecary.Models
{
    public class VisitLog
    {
        public int Id { get; set; }
        public string? Name { get; set; }  
        public DateTime AppointmentDate { get; set; } 
        public string? Notes { get; set; }     
    }
}