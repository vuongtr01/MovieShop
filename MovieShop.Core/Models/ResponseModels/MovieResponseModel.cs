using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models.ResponseModels;

public class MovieResponseModel
{
    [Required]
    public int Id { get; set; }
    public string? BackdropUrl { get; set; }
    public float? Budget { get; set; }
    public string? CreateBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ImdbUrl { get; set; }
    public string? Overview { get; set; }
    public string? PosterUrl { get; set; }
    public float? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public float? Revenue { get; set; }
    public int? RunTime { get; set; }
    public string? Tagline { get; set; }
    public string? Title { get; set; }
    public string? TmdbUrl { get; set; }
}