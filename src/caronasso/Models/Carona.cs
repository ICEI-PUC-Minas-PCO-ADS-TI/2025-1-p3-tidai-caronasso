using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class Carona
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Origem { get; set; }

    [Required]
    public string Destino { get; set; }

    [Required]
    [Display(Name = "Horário de Saida")]
    public DateTime HorarioSaida { get; set; }

    [Display(Name = "Número de vagas disponíveis")]
    public int VagasDisponiveis { get; set; }

    public int MotoristaId { get; set; }

    [ForeignKey(nameof(MotoristaId))]
    public Usuario Motorista { get; set; }

    [InverseProperty(nameof(CaronaPassageiro.Carona))]
    public List<CaronaPassageiro> Passageiros { get; set; } = new List<CaronaPassageiro>();


}
