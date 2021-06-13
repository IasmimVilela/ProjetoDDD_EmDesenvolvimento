using AutoMapper;
using ProjatoDDD.Domain.Entities;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IMapper Mapper;
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp, IMapper Mapper)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
            this.Mapper = Mapper;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());
            return View(produtoViewModel);
        }

        public ActionResult BuscarProNome(string nome)
        {
            var produtoModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.BuscarPorNome(nome));
            return View(produtoModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        [HttpPost]
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(_clienteApp.GetAll(), "IdCliente", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(_clienteApp.GetAll(), "IdCliente", "Nome");
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.IdCliente = new SelectList(_clienteApp.GetAll(), "IdCliente", "Nome");

            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProdutoViewModel produto)
        {
            var pro = _produtoApp.GetById(id);
            _produtoApp.Remove(pro);
            return View("Index");
        }
    }
}
