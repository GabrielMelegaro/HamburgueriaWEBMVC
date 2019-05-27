using System;
using Hamburgueria_Tarde.Models;
using Hamburgueria_Tarde.Repositorio;
using Hmaburgueria_MVC.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamburgueria_Tarde.Controllers{
    public class PedidoController : Controller{
        private PedidoRepositorio Repositorio = new PedidoRepositorio();
        private HamburguerRepositorio hamburguerRepositorio = new HamburguerRepositorio();
        private ShakeRepositorio shakeRepositorio = new ShakeRepositorio();
        [HttpGet]
        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepositorio.Listar();
            var shakes = shakeRepositorio.Listar();

            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;

            return View(pedido);
        }

        [HttpPost]
        public IActionResult RegistrarPedido(IFormCollection form){
            System.Console.WriteLine(form["nome"]);
            System.Console.WriteLine(form["endereco"]);
            System.Console.WriteLine(form["telefone"]);
            System.Console.WriteLine(form["email"]);
            System.Console.WriteLine(form["hamburguer"]);
            System.Console.WriteLine(form["shake"]);

            Pedido pedido = new Pedido();

            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];

            pedido.Cliente = cliente;            

            Hamburguer hamburguer = new Hamburguer(
                Nome: form["hamburguer"],
                Preco: hamburguerRepositorio.ObterPrecoDe(form["hamburguer"])
            );
                
            pedido.Hamburguer = hamburguer;

            Shake shake = new Shake() {
                Nome = form["shake"],
                Preco = shakeRepositorio.ObterPrecoDe(form["shake"])
            };

            pedido.Shake = shake;


            ViewData["NomeView"] = "Pedido";

            Repositorio.Inserir(pedido);
            
            return  View("Sucesso");
        }
    }
}