using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models.ResponseModels;

public class MovieCastResponseModel
{
    public int Id { get; set; }
    [Required]
    public string Character { get; set; }
    [Required]
    public string Name { get; set; }
    public string ProfilePath { get; set; }
}