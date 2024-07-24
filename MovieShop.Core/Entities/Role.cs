using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class Role
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public List<UserRole> UserRoles { get; } = [];
    public List<User> Users { get; } = [];
}