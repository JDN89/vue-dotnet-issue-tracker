using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;

public class RegisterDto
{
    [Required] 
    public string? Username { get; set; }
    [Required] 
    [EmailAddress] 
    public string? Email { get; set; }

    [Required]
    // At least one number, lowerCase,upperCase and length between 4 and 8 char
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex")]
    public string? Password { get; set; }
}