using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models.ResponseModels;

public class GenreResponseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}