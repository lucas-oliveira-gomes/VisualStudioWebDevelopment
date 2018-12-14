using AspNetVS2017.Capitulo03.Portfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Capitulo03.Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            const string diretornioImagens = "/Content/Imagens/Portfolio";
            var caminhos = Directory.EnumerateFiles(Server.MapPath(diretornioImagens));

            PortfolioViewModel viewModel = new PortfolioViewModel();

            foreach (var caminho in caminhos)
            {
                viewModel.CaminhosImagens.Add($"{diretornioImagens}/{Path.GetFileName(caminho)}");
            }

            return View(viewModel);
        }
    }
}