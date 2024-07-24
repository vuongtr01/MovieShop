using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class Review
{
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public float Rating { get; set; }
    [Required]
    public string ReviewText { get; set; }
}