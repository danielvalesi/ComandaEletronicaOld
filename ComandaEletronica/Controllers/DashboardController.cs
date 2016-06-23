using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComandaEletronica.Entity;
using ComandaEletronica.Models;

namespace ComandaEletronica.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard do Funcionario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dashboard do Cliente
        public ActionResult Cliente()
        {
            using (ProdutoModel model = new ProdutoModel())
            {
                List<Produto> lista = model.Read();
                return View(lista);
            }
        }

        public ActionResult Adicionar(int id)
        {
            // acessando o banco e pegar os dados do produto

            //Conta conta = (Conta)Session["carrinho"];
            if(Session["Pedido"] == null)
                Session["Pedido"] = new Pedido();
            
            ((Pedido)Session["Pedido"]).Itens.Add(new Item() { Produto_Id =  id});

            return RedirectToAction("Cliente");

        }

        public ActionResult Finalizar()
        {
            // acessando o banco e pegar os dados do produto

            Conta conta = (Conta)Session["carrinho"];

            conta.Pedidos.Add((Pedido)Session["Pedido"]);

        }

    }
}