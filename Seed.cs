using TuesdayAlphaApi.Data;
using TuesdayAlphaApi.Models;

namespace TuesdayAlphaApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            
            if (!dataContext.ParentCities.Any())
            {
                var cities = new List<ParentCity>()
                {
                    new ParentCity()
                    {
                        
                        Name = "Gainesville",
                        
                        WeeklySpecials = new List<Weekly>()
                        {
                            new Weekly { Name ="Flaco's Karaoke Taco Tuesday", Venue = new Venue {Name="Flaco's", Url="https://flacosgnv.com/" }, 
                            PromoText="Karaoke @ Vecino's signup starts at 9pm", Category = new Category { Name ="Karaoke" }},

                            new Weekly { Name ="Open Mic at Sacred Remedy", Venue = new Venue {Name="Sacred Remedy", Url="https://sacredremedies.com/" }, 
                            PromoText="A forum for individualistic expression in any thoughtful or creative way you feel like bringing it.", Category = new Category {Name ="Open Mic"}}, 
                        },

                        MonthlyEvents = new List<Monthly>()
                        {
                            new Monthly { Name ="Traditional Irish Sessions", Venue = new Venue {Name="Lightnin Enterprises", Url="https://www.lightninsalvageenterprises.com/" }, 
                            PromoText="Traditional Irish Music While You Eat Pizza and Drink Craft Beer", Category = new Category {Name ="Live Music"}, WeekNumber = 2},   
                        },

                        OneTimeEvents = new List<OneTimeEvent>()
                        {
                            new OneTimeEvent { Name ="Gator's Softball Vs. Texas State", Venue = new Venue {Name="Katie Seashole Pressly Stadium", Url="https://floridagators.com/sports/2020/4/4/katie-seashole-pressly-stadium.aspx" }, 
                            PromoText="Come see the Gators Clash with the Spartans.  Fireworks after the game.", Category =  new Category {Name ="Spectator Sports"}, EventDate = new DateTime(2023,5,1)},   
                        }
                       
                    }, 
                    new ParentCity()
                    {
                        
                        Name = "South Park",
                        
                        WeeklySpecials = new List<Weekly>()
                        {
                            new Weekly { Name ="El Diablo's Taco Tuesday", Venue = new Venue {Name="El Diablo's", Url="https://www.chipotle.com/" }, 
                            PromoText="5 Cents off Burritos when you mention this", Category = new Category { Name ="Food Special" }},
                        },

                        MonthlyEvents = new List<Monthly>()
                        {
                            new Monthly { Name ="Dodge Ball Night", Venue = new Venue {Name="South Park Community Center", Url="https://southpark.cc.com/" }, 
                            PromoText="Release your frustrations together", Category = new Category {Name ="Adult Sports Leaugue"}, WeekNumber = 3},   
                        },

                        OneTimeEvents = new List<OneTimeEvent>()
                        {
                            new OneTimeEvent { Name ="Al Gore Discusses ManBearPig", Venue = new Venue {Name="South Park Fairgrounds", Url="https://southpark.cc.com/topic/south-park-events" }, 
                            PromoText="Former Vice Preisdent Initiates a Cryptozoology Conversation", Category =  new Category {Name ="Speaking Engagement"}, EventDate = new DateTime(2023,6,1)},   
                        }
                       
                    },   
                };
            
                dataContext.ParentCities.AddRange(cities);
                dataContext.SaveChanges();
            }
        }
    }
}