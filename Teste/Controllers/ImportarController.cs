using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Teste.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImportarController : ControllerBase
    {
        // GET api/values
        
        public ImportarController (ProdutoContexto context)
        {
            Context = context;
        }

        public ProdutoContexto Context { get; }

        // GET api/values/5


        /*public string Get([FromHeader]string conteudo)
        {
            return Context.Produto.FirstOrDefault().CodGtin;
        }*/
        [HttpGet]
        public IEnumerable<Produto> Get([FromHeader]string cod)
        {
            List<Produto> produtos = new List<Produto>();
            string[] linhas = cod.Split("\n");
            for(int i = 0; i < linhas.Length;i++)
            {
                string[] colunas = linhas[i].Split(',');
                Produto produto = new Produto();
                produto.CodGtin = colunas[0];
                produto.DataEmissao = colunas[1];
                produto.CodTipoPagamento = (colunas[2]);
                produto.CodProduto = int.Parse(colunas[3]);
                produto.CodNcm = int.Parse(colunas[4]);
                produto.CodUnidade = (colunas[5]);
                produto.DscProduto = colunas[6];
                produto.VlrUnitario = float.Parse(colunas[7]);
                produto.IdEstabelecimento = int.Parse(colunas[8]);
                produto.NmeEstabelecimento = colunas[9];
                produto.NmeLogradouro = colunas[10];
                produto.CodNumeroLogradouro = int.Parse(colunas[11]);
                produto.NmeComplemento = colunas[12];
                produto.NmeBairro = colunas[13];
                produto.CodMunicipioIbge = int.Parse(colunas[14]);
                produto.NmeMunicipio = colunas[15];
                produto.NmeSigleUf = colunas[16];
                produto.CodCep = int.Parse(colunas[17]);
                produto.NumLatitude = colunas[18];
                produto.NumLongitude = colunas[19];

                produtos.Add(produto);
            }
            Context.Produto.AddRange(produtos);
            Context.SaveChanges();

            return produtos;
        }

       /*public ActionResult<int> Get([FromHeader]int id)
        {
            return id;
        }*/

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
