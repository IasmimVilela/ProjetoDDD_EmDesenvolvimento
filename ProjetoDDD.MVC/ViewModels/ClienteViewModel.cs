using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres para nome")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres para nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres para sobrenome")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres para sobrenome")]
        public string Sobrenome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres para E-mail")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres para E-mail")]
        [EmailAddress(ErrorMessage = "´Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}