using System.ComponentModel.DataAnnotations;

namespace caronasso.Models.Enums;

public enum Genero
{
    Homem,
    Mulher,
    [Display(Name = "Não Binário")]
    NaoBinario,
    Outro,
    [Display(Name = "Prefiro não dizer")]
    NaoDizer
}
