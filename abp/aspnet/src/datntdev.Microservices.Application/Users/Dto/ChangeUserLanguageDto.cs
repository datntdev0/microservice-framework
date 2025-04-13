using System.ComponentModel.DataAnnotations;

namespace datntdev.Microservices.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}