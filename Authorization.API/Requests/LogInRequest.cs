using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Authentication.API.Requests;

public class LogInRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
