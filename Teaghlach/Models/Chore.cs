using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MudBlazor;
using Teaghlach.Models;

namespace Teaghlach.Data
{
    public class Chore: IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public ChoreType Type { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; } = false;

        // Foreign key to FamilyMember
        [Required(ErrorMessage = "Family Member is required")]
        public int? AssignedToId { get; set; }

        [ForeignKey("AssignedToId")]
        public FamilyMember? AssignedTo { get; set; }

        public DateTime CreatedAt { get; set; } //= DateTime.UtcNow;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DueDate < CreatedAt)
            {
                yield return new ValidationResult(
                    "Due date cannot be earlier than created date.",
                    new[] { nameof(DueDate), nameof(CreatedAt) });
            }
        }

    }
}
