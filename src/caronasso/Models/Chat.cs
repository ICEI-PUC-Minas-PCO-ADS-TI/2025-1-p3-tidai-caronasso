using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class Chat
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Título")]
    public string Titulo { get; set; }

    [Display(Name = "Data da criação")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [Display(Name = "Data da última mensagem")]
    public DateTime UltimaMensagemData { get; set; }

    [InverseProperty(nameof(ChatParticipante.Chat))]
    public List<ChatParticipante> Participantes { get; set; } = new List<ChatParticipante>();

    [InverseProperty(nameof(Mensagem.Chat))]
    public List<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

}
