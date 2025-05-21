using System.ComponentModel.DataAnnotations;

namespace caronasso.Models.Enums;

public enum Curso
{
    [Display(Name = "Análise e Desenvolvimento de Sistemas")]
    ADS,
    [Display(Name = "Engenharia de Software")]
    EngenhariaSoftware,
    [Display(Name = "Ciência da Computação")]
    CienciaComputacao,
    [Display(Name = "Sistemas de Informação")]
    SistemasInformacao
}
