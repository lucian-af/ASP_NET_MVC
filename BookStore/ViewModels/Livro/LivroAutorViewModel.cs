using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Livro
{
    public class LivroAutorViewModel
    {
        [Required(ErrorMessage = "*")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "*")]
        public int LivroId { get; set; }
    }
}