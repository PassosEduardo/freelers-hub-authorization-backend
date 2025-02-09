using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Requests;

public class SignUpRequest
{
    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(50, ErrorMessage = "Password Lenght must be between 6-50 characters", MinimumLength = 6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Re-Password is required")]
    [Compare("Password")]
    public string RePassword { get; set; }
}
