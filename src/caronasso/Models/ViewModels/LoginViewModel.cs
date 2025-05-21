using caronasso.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace caronasso.Models.ViewModels;

public class LoginViewModel
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
    [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório!")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}
