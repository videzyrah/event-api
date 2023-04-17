namespace TuesdayAlphaApi.Models
{
    public class ParentCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Weekly> WeeklySpecials { get; set; }
        public ICollection<Monthly> MonthlyEvents { get; set; }
        public ICollection<OneTimeEvent> OneTimeEvents { get; set; }
        //public ICollection<Venue> Venues { get; set; }
    }
}