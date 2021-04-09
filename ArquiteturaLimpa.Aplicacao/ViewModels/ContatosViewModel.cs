using System.ComponentModel.DataAnnotations;

namespace ArquiteturaLimpa.Aplicacao.ViewModels
{
    public class ContatosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MaxLength(9)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(14)]
        public string CPF { get; set; }
    }
}
