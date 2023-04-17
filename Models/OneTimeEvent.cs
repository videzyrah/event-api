namespace TuesdayAlphaApi.Models
{
    public class OneTimeEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue? Venue  { get; set; }
        public string? Url { get; set; }
        public string  PromoText { get; set; }

        //Food special, Karaoke, Comedy, Trivia, Open Mic, Adult Sports League, Spectator Sports
        public Category Category { get; set; }
        public DateTime EventDate { get; set; }
        public ParentCity ParentCity { get; set; }
    }
}