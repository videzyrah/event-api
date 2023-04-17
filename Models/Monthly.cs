namespace TuesdayAlphaApi.Models
{
    public class Monthly
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public Venue? Venue  { get; set; }
        public string? Url { get; set; }
        public string  PromoText { get; set; }
        //Food special, Karaoke, Comedy, Trivia, Open Mic, Meetup
        public Category Category { get; set; }
        public int WeekNumber { get; set; }
        public ParentCity ParentCity { get; set; }
    }
}