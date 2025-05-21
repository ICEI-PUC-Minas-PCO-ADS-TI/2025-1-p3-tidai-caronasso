using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class ChatParticipante
{
    public int ChatId { get; set; }

    [ForeignKey(nameof(ChatId))]
    [InverseProperty(nameof(Chat.Participantes))]
    public Chat Chat { get; set; }

    public int UsuarioId { get; set; }

    [ForeignKey(nameof(UsuarioId))]
    [InverseProperty(nameof(Usuario.Chats))]
    public Usuario Usuario { get; set; }
}
