using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Entities;

public class Cast
{
    public int Id { get; set; }
    
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }

    public List<MovieCasts> MovieCasts { get;} = [];
    public List<Movie> Movies { get;} = [];
}