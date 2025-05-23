using System.ComponentModel.DataAnnotations;

namespace Teaghlach.Models
{
    public class FamilyRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<FamilySubRole> FamilySubRoles { get; set; } = new List<FamilySubRole>();

    }
}
