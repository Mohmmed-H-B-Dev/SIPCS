namespace SIPCS.Common.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;  // مدير، كاشير، أمين مخزن
        public string? Description { get; set; }
    }
}
