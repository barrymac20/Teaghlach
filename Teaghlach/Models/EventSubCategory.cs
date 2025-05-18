namespace Teaghlach.Models
{
    public class EventSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; } = null!;
    }

}
