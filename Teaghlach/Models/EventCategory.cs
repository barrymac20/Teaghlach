namespace Teaghlach.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<EventSubCategory> EventSubCategories { get; set; } = new List<EventSubCategory>();
    }
}