using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using System.Collections.Generic; 
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;


namespace Teste.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET api/values
        
        public ProdutoController (ProdutoContexto context)
        {
            Context = context;
        }

        public ProdutoContexto Context { get; }

        // GET api/values/5

      /*  [HttpGet]
        public string Get([FromHeader]string cod)
        {
            return Context.Produto.FirstOrDefault().CodGtin;
        }*/
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get([FromHeader]string cod)
        {
            if (!string.IsNullOrEmpty(cod))
            {
                var a = Context.Produto.Where(x => x.CodGtin == cod && x.VlrUnitario != 0.0f && !string.IsNullOrEmpty(x.NumLatitude) && !string.IsNullOrEmpty(x.NumLongitude)).OrderBy(x=> x.VlrUnitario);
                return Ok(a);
            }
            else
            {
                return BadRequest();
            }
            
            
        }



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
