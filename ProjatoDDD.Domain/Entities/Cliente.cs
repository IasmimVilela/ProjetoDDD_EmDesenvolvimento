using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjatoDDD.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string  Sobrenome {get; set;}
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; } 

        public bool ClienteEspecial(Cliente cliente) 
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }
    }
}
 