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

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; } // e.g. Birthday, Match, School, etc.


        public string? Color { get; set; } = "#fff"; // Default blue color

        public int? FamilyMemberId { get; set; }

        [ForeignKey("FamilyMemberId")]
        public FamilyMember? FamilyMember { get; set; }

        public int? EventCategoryId { get; set; }
        public EventCategory? EventCategory { get; set; }

        public int? EventSubCategoryId { get; set; }
        public EventSubCategory? EventSubCategory { get; set; }


    }
}
