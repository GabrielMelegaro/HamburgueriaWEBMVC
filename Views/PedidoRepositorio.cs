using System;
using System.IO;
using Hamburgueria_Tarde.Models;

namespace Hamburgueria_Tarde.Views
{
    public class PedidoRepositorio
    {
        public bool Inserir(Pedido pedido){
            try{

            if(!File.Exists("Database/Pedido.csv")){
                File.Create("Database/Pedido.csv").Close();
            }

            var registro = $"{pedido.Id};{pedido.Cliente.Nome};{pedido.Cliente.Endereco};{pedido.Cliente.Telefone};{pedido.Cliente.Email};{pedido.Hamburguer.Nome};{pedido.Shake.Nome};{pedido.DataPedido};"; 

            File.AppendAllText("Database/Pedido.csv", registro);
            }catch(Exception e) {
                System.Console.WriteLine("Chegou no catch!");
                System.Console.WriteLine(e.StackTrace);
            }
        
            return true;
        }   
    }
}