using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class Purchase
{
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public DateTime PurchaseDateTime { get; set; }
    [Required]
    public Guid PurchaseNumber { get; set; }
    [Required]
    public float TotalPrice { get; set; }
}