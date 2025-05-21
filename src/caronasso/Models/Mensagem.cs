using caronasso.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class Mensagem
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Insira o texto a ser enviado")]
    [Display(Name = "Conteúdo")]
    public string Conteudo { get; set; }

    [Display(Name = "Horário de envio")]
    public DateTime HorarioEnvio { get; set; } = DateTime.Now;

    public int ChatId { get; set; }

    [ForeignKey(nameof(ChatId))]
    [InverseProperty(nameof(Chat.Mensagens))]
    public Chat Chat { get; set; }

    public int RemetenteId { get; set; }

    [ForeignKey(nameof(RemetenteId))]
    [InverseProperty(nameof(Usuario.MensagensEnviadas))]
    public Usuario Remetente { get; set; }
}
