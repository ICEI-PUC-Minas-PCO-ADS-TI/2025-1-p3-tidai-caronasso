using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class AvaliacaoUsuario
{
    [Key]
    public int Id { get; set; }

    [Range(1, 5)]
    [Display(Name = "Nota")]
    public int Nota { get; set; }

    [Display(Name = "Comentário")]
    public string Comentario { get; set; }

    [Display(Name = "Id Usuário Avaliado")]
    public int UsuarioAvaliadoId { get; set; }

    [ForeignKey(nameof(UsuarioAvaliadoId))]
    public Usuario UsuarioAvaliado { get; set; }

    [Display(Name = "Id Usuário Avaliador")]
    public int UsuarioAvaliadorId { get; set; }

    [ForeignKey(nameof(UsuarioAvaliadorId))]
    public Usuario UsuarioAvaliador { get; set; }

    public DateTime DataAvaliacao { get; set; } = DateTime.Now;
}
