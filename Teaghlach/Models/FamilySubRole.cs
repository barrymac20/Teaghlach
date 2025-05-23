namespace Teaghlach.Models
{
    public class FamilySubRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FamilyRoleId { get; set; }
        public FamilyRole FamilyRole { get; set; } = null!;
    }
}