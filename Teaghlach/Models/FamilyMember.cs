using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teaghlach.Data;

namespace Teaghlach.Models
{
    public class FamilyMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Role { get; set; } // e.g. "Parent", "Child", etc.

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        public List<Chore>? Chores { get; set; }

        [Required]
        public int? FamilyRoleId { get; set; }

        public FamilyRole? FamilyRole { get; set; }

        public int? FamilySubRoleId { get; set; }
        public FamilySubRole? FamilySubRole { get; set; }

        
        //[Required]
        //[MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        //[Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
