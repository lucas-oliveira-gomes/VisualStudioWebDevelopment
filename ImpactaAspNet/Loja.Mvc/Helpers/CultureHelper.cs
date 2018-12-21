using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ViagensOnline.Mvc.Models;

namespace Loja.Mvc.Helpers
{
    public class CultureHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string linguagemSelecionada = LinguagemPadrao;
        private List<string> linguagensSuportadas = new List<string> { "pt-BR", "en-US", "es" };


        public CultureHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }


        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }

        public static CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current.Request.Cookies[Cookie.LinguagemSelecionada];
            var liguagem = linguagemSelecionada?.Value ?? LinguagemPadrao;
            return CultureInfo.CreateSpecificCulture(liguagem);
        }

        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request;
            if (request.Cookies[Cookie.LinguagemSelecionada] != null)
            {
                linguagemSelecionada = request.Cookies[Cookie.LinguagemSelecionada].Value;
                return;
            }
            if (request.UserLanguages != null && linguagemSelecionada.Contains(request.UserLanguages[0]))
            {
                linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie(Cookie.LinguagemSelecionada, linguagemSelecionada);
            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }
    }
}