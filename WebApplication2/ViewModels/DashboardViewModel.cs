using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class DashboardViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public string? ProfileImageUrl { get; set; }
        public List<Race> Races { get; set; }
        public List<Club> Clubs { get; set; }
    }
}
