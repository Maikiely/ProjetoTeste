using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace UnidadeTeste
{
    [TestClass]
    public class UnitTest1
    {

        ProdutoContexto Context;

        [TestInitialize]
        public void Inicio()
        {

            DbContextOptionsBuilder<ProdutoContexto> builder = new DbContextOptionsBuilder<ProdutoContexto>();
            DbContextOptionsBuilder<ProdutoContexto> builderSqlite = builder.UseSqlite("Data Source=data.sqlite");
            Context = new ProdutoContexto(builderSqlite.Options);

        }

        [TestCleanup]
        public void Fim()
        {
            Context.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string cod = "7893000394117,07/02/2019 13:35:45,01,100,15171000,UN,MARGARINA QUALY C/SAL 250G,3.99,131966,Estabelecimento 14,RUA MANOEL JOAQUIM DOS SANTOS,2,,ITACIBA,3201308,CARIACICA,ES,29150270,-20.3204997,-40.3819473"; 
            if (!string.IsNullOrEmpty(cod))
            {
                List<Produto> produtos = new List<Produto>();
                string[] linhas = cod.Split("\n");
                for (int i = 0; i < linhas.Length; i++)
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

                Assert.IsTrue(produtos.Any());
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void TestMethod2()
        {
            string cod= "0040232721748";
            string log = string.Empty;
            if (!string.IsNullOrEmpty(cod))
            {

                var a = Context.Produto.Where(x => x.CodGtin == cod && x.VlrUnitario != 0.0f && !string.IsNullOrEmpty(x.NumLatitude) && !string.IsNullOrEmpty(x.NumLongitude)).OrderBy(x => x.VlrUnitario);
                log = $"Data do log: {DateTime.Now}; Codigo GTIN: {cod}; Status da requsição: 200; Qunatidade de produtos retornados: {a.Count()}";
                System.IO.File.AppendAllText("log.txt", log);
                Assert.IsTrue(a.Any());
            }
            else
            {
                log = $"Data do log: {DateTime.Now}; Codigo GTIN: {cod}; Status da requsição: 400; Qunatidade de produtos retornados: 0";
                System.IO.File.AppendAllText("log.txt", log);
                Assert.Fail();
            }
        }

    }
}
