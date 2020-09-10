using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Dominio;

namespace BookStore.ViewModels
{
    public class EditorLivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nome do Livro")] // essa propriedade reflete no @Html.label
        public string Nome { get; set; }

        [Required(ErrorMessage = "*")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Data do Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Data do Lançamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataLancamentoGrid { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public SelectList CategoriaOptions { get; set; }
    }
}