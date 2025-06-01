using caronasso.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace caronasso.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    public Curso Curso { get; set; }

    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }

    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Display(Name = "Gênero")]
    public Genero Genero { get; set; } = Genero.NaoDizer;

    [Display(Name = "Disponível")]
    public bool Disponivel { get; set; } = false;

    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Foto de Perfil")]
    public string? FotoPerfil { get; set; }

    public Perfil Perfil { get; set; } = Perfil.User;

    [InverseProperty(nameof(ChatParticipante.Usuario))]
    public List<ChatParticipante> Chats { get; set; } = new List<ChatParticipante>();

    [InverseProperty(nameof(Mensagem.Remetente))]
    public List<Mensagem> MensagensEnviadas { get; set; } = new List<Mensagem>();

    [InverseProperty(nameof(Carona.Motorista))]
    public List<Carona> CaronasComoMotorista { get; set; } = new List<Carona>();

    [InverseProperty(nameof(CaronaPassageiro.Usuario))]
    public List<CaronaPassageiro> CaronasComoPassageiro { get; set; } = new List<CaronaPassageiro>();

    [InverseProperty(nameof(AvaliacaoUsuario.UsuarioAvaliado))]
    public List<AvaliacaoUsuario> AvaliacoesRecebidas { get; set; } = new List<AvaliacaoUsuario>();

    [InverseProperty(nameof(AvaliacaoUsuario.UsuarioAvaliador))]
    public List<AvaliacaoUsuario> AvaliacoesEnviadas { get; set; } = new List<AvaliacaoUsuario>();

    [NotMapped]
    public float? MediaAvaliacao => AvaliacoesRecebidas.Any() == true ? 
        (float)Math.Round(AvaliacoesRecebidas.Average(a => a.Nota), 2) :
        null;

    [NotMapped]
    public int QuantidadeAvaliacoes => AvaliacoesRecebidas?.Count ?? 0;

}
