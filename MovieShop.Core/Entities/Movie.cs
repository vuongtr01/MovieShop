using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    
    [Column(TypeName = "nvarchar(2048)")]
    public string? BackdropUrl { get; set; }
    
    [Column(TypeName = "decimal(18, 4)")]
    public float? Budget { get; set; }
    public string? CreateBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    
    [Column(TypeName = "nvarchar(2048)")]
    public string? ImdbUrl { get; set; }
    
    [Column(TypeName = "nvarchar(64)")]
    public string? OriginalLanguage { get; set; }
    
    public string? Overview { get; set; }
    
    [Column(TypeName = "nvarchar(2048)")]
    public string? PosterUrl { get; set; }
    
    [Column(TypeName = "decimal(5, 2)")]
    public float? Price { get; set; }
    
    public DateTime? ReleaseDate { get; set; }
    
    [Column(TypeName = "decimal(18, 4)")]
    public float? Revenue { get; set; }
    
    public int? RunTime { get; set; }
    
    [Column(TypeName = "nvarchar(512)")]
    public string? Tagline { get; set; }
    
    [Column(TypeName = "nvarchar(256)")]
    public string? Title { get; set; }
    
    [Column(TypeName = "nvarchar(2048)")]
    public string? TmdbUrl { get; set; }
    
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public List<MovieCasts> MovieCasts { get; } = [];
    public List<Cast> Casts { get;} = [];
    public List<MovieGenres> MovieGenres { get; } = [];
    public List<Genre> Genres { get;} = [];
    public List<Favorite> Favorites { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Purchase> Purchases { get; set; }
    public List<Trailer> Trailers { get; } = [];
}