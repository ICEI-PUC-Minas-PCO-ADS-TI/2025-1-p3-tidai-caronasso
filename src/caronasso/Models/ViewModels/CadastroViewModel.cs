using caronasso.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace caronasso.Models.ViewModels;

public class CadastroViewModel
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório!")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo curso é obrigatório!")]
    public Curso Curso { get; set; }

    [Display(Name = "Gênero")]
    [Required(ErrorMessage = "O campo gênero é obrigatório!")]
    public Genero Genero { get; set; }
}
