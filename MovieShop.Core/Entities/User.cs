using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Core.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(256)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(1024)")]
    public string HashedPassword { get; set; }
    public bool IsLocked { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(1024)")]
    public string Salt { get; set; }
    
    public List<Favorite> Favorites { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Purchase> Purchases { get; set; }
    public List<UserRole> UserRoles { get; } = [];
    public List<Role> Roles { get; } = [];
}