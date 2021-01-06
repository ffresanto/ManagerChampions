using ManagerChampions.Models;
using ManagerChampions.Models.Home;
using ManagerChampions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerChampions.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult TrofeusIndividuais()
        {

            var premiosIndividuaisModel = new HomePremiosIndividuaisModel();
            premiosIndividuaisModel.ListaPremiosIndividuais = new PremiosIndividuaisService().Lista();

            return View(premiosIndividuaisModel);
        }

        public ActionResult TrofeusIndividuaisCadastro(int? id = 0)
        {
            if (id != 0)
            {
                var premiosIndividuais = new PremiosIndividuaisService().Detalhe(id);
                return View(premiosIndividuais);
            }

            PremiosIndividuais premiosIndividuaisVazio = new PremiosIndividuais();
            return View(premiosIndividuaisVazio);
        }

        [HttpPost]
        public ActionResult TrofeusIndividuaisCadastro(FormCollection form)
        {
            PremiosIndividuais premiosIndividuais = new PremiosIndividuais();

            premiosIndividuais.Descricao = form["Descricao"];

            var retorno = new PremiosIndividuaisService().Salvar(premiosIndividuais);

            if (retorno == true)
            {
                return RedirectToAction("TrofeusIndividuais");
            }
            else
            {
                return View();
            }
        }

        public ActionResult TrofeusIndividuaisExcluir(int id)
        {
            var retorno = new PremiosIndividuaisService().Excluir(id);
            return RedirectToAction("TrofeusIndividuais");
        }

        public ActionResult TrofeusIndividuaisEditar(FormCollection form)
        {
            PremiosIndividuais premiosIndividuais = new PremiosIndividuais();

            premiosIndividuais.Descricao = form["Descricao"];
            premiosIndividuais.IdPremioIndividual = Convert.ToInt32(form["IdPremioIndividual"]);

            var retorno = new PremiosIndividuaisService().Salvar(premiosIndividuais);
            return RedirectToAction("TrofeusIndividuais");
        }
    }
}