using System.ComponentModel.DataAnnotations;

namespace EFCoreWebApi.Client.Models;

public class BookDto
{
    [Required(ErrorMessage = "BookId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "BookId must be more than 0")]
    public int BookId { get; set; }

    [Required(ErrorMessage ="Title is required")]
    public string Title { get; set; } = null!;

    public string? Author { get; set; }
    [Required(ErrorMessage = "Published Year is required")]
    [CurrentYearRange(2000)]
    public int? PublishedYear { get; set; }

    public string? Isbn { get; set; }

    public decimal? Price { get; set; }


}

//Custom validation attribute
public class CurrentYearRangeAttribute : ValidationAttribute
{
    private readonly int _minYear;

    public CurrentYearRangeAttribute(int minYear)
    {
        _minYear = minYear;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        
        if (value is int year) 
        {
            int currentYear = DateTime.Now.Year;
            if(year < _minYear || year > currentYear)
            {
                return new ValidationResult($"Publiched year must be between {_minYear} and {currentYear}.");
            }
        }
        return ValidationResult.Success;
    }
}