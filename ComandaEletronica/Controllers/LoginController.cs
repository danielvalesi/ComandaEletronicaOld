using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComandaEletronica.Models;
using ComandaEletronica.Entity;

namespace ComandaEletronica.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            using(FuncionarioModel Model = new FuncionarioModel())
            {
                Funcionario e = Model.Read(form["email"], form["senha"]);

                if (e == null)
                {
                    return RedirectToAction("index");
                } else
                {
                    Session["funcionario"] = e;
                    return RedirectToAction("index", "dashboard");

                    /* FAZER LOGINS PARA CADA TIPO DE USUARIO
                    Session["conta"] = e;
                    return RedirectToAction("index", "dashboard");
                    */

                    /* // Retornando o funcionario 
                    Funcionario x = (Funcionario)Session["funcionario"];
                    x.Nome;
                    */

                }
            } 


        }
    }
}
