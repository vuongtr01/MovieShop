using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models.ResponseModels;

public class ReviewRequestModel
{
    public float Rating { get; set; }
    [Required]
    public string ReviewText { get; set; }
}