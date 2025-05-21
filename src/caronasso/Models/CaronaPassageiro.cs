using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class CaronaPassageiro
{
    public int CaronaId { get; set; }

    [ForeignKey(nameof(CaronaId))]
    [InverseProperty(nameof(Carona.Passageiros))]
    public Carona Carona { get; set; }

    public int UsuarioId { get; set; }

    [ForeignKey(nameof(UsuarioId))]
    [InverseProperty(nameof(Usuario.CaronasComoPassageiro))]
    public Usuario Usuario { get; set; }
}
