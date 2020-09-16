using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BookStore.Dominio;
using BookStore.Validacao;

namespace BookStore.ViewModels.Livro
{
    public class EditorLivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido!")]
        [Display(Name = "Nome do Livro")] // essa propriedade reflete no @Html.label
        public string Nome { get; set; }

        [Required(ErrorMessage = "ISBN inválido!")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Data inválida!")]
        [Display(Name = "Data do Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [ValidarData]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Data do Lançamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataLancamentoGrid { get; set; }

        [Required(ErrorMessage = "Selecione a categoria!")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public SelectList CategoriaOptions { get; set; }
    }
}