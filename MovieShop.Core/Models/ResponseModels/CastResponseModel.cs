using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models.ResponseModels;

public class CastResponseModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
    
    public List<MovieResponseModel> movies { get; set; }
}