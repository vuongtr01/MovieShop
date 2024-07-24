using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Core.Entities;

public class Trailer
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string TrailerUrl { get; set; }
    [Required]
    public int MovieId { get; set; }

    public Movie Movie { get; set; } = null!;
}