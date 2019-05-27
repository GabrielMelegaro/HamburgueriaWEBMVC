using System;
using System.IO;
using Hamburgueria_Tarde.Models;

namespace Hmaburgueria_MVC.Repositorio{
   public class PedidoRepositorio{
       private const string PATH = "Database/Pedido.csv";
       public bool Inserir(Pedido pedido)
       {
           try{

           if(!File.Exists(PATH)){
               //Codigo de criação do arquivo
               File.Create(PATH).Close();
           }
           var registro = $"{pedido.Id};{pedido.Cliente.Nome};{pedido.Cliente.Endereco};{pedido.Cliente.Telefone};{pedido.Cliente.Email};{pedido.DataPedido};{pedido.Hamburguer.Nome};{pedido.Hamburguer.Preco};{pedido.Shake.Nome};{pedido.Shake.Preco};{pedido.DataPedido};{pedido.PrecoTotal}\n";
               //Codigo de gravação
           File.AppendAllText(PATH,registro);
           }catch(Exception e){
               System.Console.WriteLine("Chegou no catch!");
               System.Console.WriteLine(e.StackTrace);
           }

           return true;
       }
   }
}