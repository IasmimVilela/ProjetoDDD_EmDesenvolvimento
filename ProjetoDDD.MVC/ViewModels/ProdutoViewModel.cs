using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres para nome")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres para nome")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }
        public int IdCliente { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}