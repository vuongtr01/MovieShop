using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class UserRole
{
    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
}