using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Autor
{
    public class EditorAutorViewModel
    {
        public int Id { get; set; }

        private string _nome;
        [Required(ErrorMessage = "Nome inválido!")]
        [Display(Name = "Nome do Autor")] // essa propriedade reflete no @Html.label        
        public string Nome { get => _nome; set => _nome = value.ToUpper(); }
    }
}