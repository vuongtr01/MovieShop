using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class MovieCasts
{
    [Required]
    public int CastId { get; set; }

    public Cast Cast { get; set; } = null!;
    
    [Required]
    public string Character { get; set; }
    
    [Required]
    public int MovieId { get; set; }

    public Movie Movie { get; set; } = null!;
}