using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Título é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Nome do diretor é obrigatório!")]
        public string Diretor { get; set; }

        [StringLength(40, ErrorMessage = "Genero com no máximo 40 caracteres.")]
        public string Genero { get; set; }

        [Range(0, 600, ErrorMessage = "Duração do filme tem que ser entre 1 min e 600 min")]
        public int Duracao { get; set; }

    }
}