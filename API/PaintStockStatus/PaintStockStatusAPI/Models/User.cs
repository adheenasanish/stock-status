namespace PaintStockStatusAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }
        public int? RoleId { get; set; }

        //public string FullName { get; set; }

        public Role  Role { get; set;}    
    }
}
