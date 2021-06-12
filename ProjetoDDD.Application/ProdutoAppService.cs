using ProjatoDDD.Domain.Entities;
using ProjatoDDD.Domain.Interfaces.Services;
using ProjetoDDD.Application.Interface;
using System.Collections.Generic;

namespace ProjetoDDD.Application
{
    class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }
    }
}
