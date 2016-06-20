using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComandaEletronica.Entity;
using ComandaEletronica.Models;

namespace ComandaEletronica.Controllers
    
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (ClienteModel model = new ClienteModel())
            {
                List<Cliente> lista = model.Read();
                return View(lista);
            }
        }

        // FILTRO POR NOMES
        [HttpPost]
        public ActionResult Filter(FormCollection form)
        {
            // Extamente o name do input search <input name="nome"...
            string nome = form["nome"];
            using (ClienteModel model = new ClienteModel())
            {
                List<Cliente> lista = model.Read(nome);
                return View("Index", lista);
            }
        }

        //GET: /Cliente/create
        public ActionResult Create()
        {
            return View();
        }

        //GET: /Cliente/create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Cliente e = new Cliente();
            e.Nome = form["nome"];
            e.Descricao = form["descricao"];
            e.Preco = decimal.Parse(form["preco"]);



            using (ClienteModel model = new ClienteModel())
            {
                model.Create(e);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            using (ClienteModel model = new ClienteModel()) { 
                return View(model.Read(id));
            }
        }



        //GET: /Cliente/update
        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            Cliente e = new Cliente();
            e.Nome = form["nome"];
            e.Descricao = form["descricao"];
            e.Preco = decimal.Parse(form["preco"]);


            e.IdCliente = int.Parse(form["idCliente"]);


            using (ClienteModel model = new ClienteModel())
            {
                model.Update(e);
            }

            return RedirectToAction("Index");
        }






        public ActionResult Delete(int id)
        {
            using (ClienteModel model = new ClienteModel())
                model.Delete(id);

                return RedirectToAction("Index");
        }

    }
}
