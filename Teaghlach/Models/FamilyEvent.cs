using Heron.MudCalendar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teaghlach.Models
{
    public class FamilyEvent : CalendarItem
    {
        [Key]
        public new int Id { get; set; }  // EF primary key

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? Color { get; set; } = "#fff"; // Default blue color

        [Required(ErrorMessage = "Family Member is required")]
        public int? FamilyMemberId { get; set; }

        [ForeignKey("FamilyMemberId")]
        public FamilyMember? FamilyMember { get; set; }

        [Required]
        public int? EventCategoryId { get; set; }
        
        public EventCategory? EventCategory { get; set; }

        public int? EventSubCategoryId { get; set; }
        public EventSubCategory? EventSubCategory { get; set; }
    }
}