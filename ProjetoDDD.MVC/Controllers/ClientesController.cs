﻿using AutoMapper;
using ProjatoDDD.Domain.Entities;
using ProjatoDDD.Domain.Interfaces;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IMapper Mapper;
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp, IMapper Mapper)
        {
            _clienteApp = clienteApp;
            this.Mapper = Mapper;
        }
        public ClientesController()
        {
            //this.Mapper = Mapper;
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }

        public ActionResult Especial()
        { 
            var clienteModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClienteEspecial());
            return View(clienteModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {   
            return View();
        }

        // GET: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            { 
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Add(clienteDomain);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
