using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class MovieGenres
{
    [Required]
    public int GenreId { get; set; }

    public Genre Genre { get; set; } = null!;
    
    [Required]
    public int MovieId { get; set; }

    public Movie Movie { get; set; } = null!;
}