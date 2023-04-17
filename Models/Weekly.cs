namespace TuesdayAlphaApi.Models
{
    public class Weekly
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue? Venue  { get; set; }
        public string  PromoText { get; set; }
        //Food special, Karaoke, Comedy, Trivia, Open Mic
        public Category? Category { get; set; }
        public ParentCity ParentCity { get; set; }
    }
}