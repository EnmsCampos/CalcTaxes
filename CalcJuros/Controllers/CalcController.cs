using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CalcJuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private double taxRate = 0.01;
        private const string GitHubUrl = "https://github.com/EnmsCampos/CalcTaxes";

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Rodando OK" };
        }

        [HttpGet]
        [Route("taxaJuros")]
        public ActionResult<string> TaxaJuros()
        {
            return this.taxRate.ToString();
        }

        [HttpGet]
        [Route("calculajuros")]
        public ActionResult<string> Calculajuros([FromQuery] double valorInicial, [FromQuery] int meses)
        {
            double valorFinal = 0.0;
            valorFinal = valorInicial * Math.Pow( (1 + taxRate) , meses);
            return string.Format("{0:N2}", valorFinal);
        }

        [HttpGet]
        [Route("showmethecode ")]
        public ActionResult<string> ShowmeTheCode()
        {
            return GitHubUrl;
        }

    }
}
