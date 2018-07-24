using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest_Authentication.Controllers
{
    [Authorize]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var dict = new Dictionary<string, string>();

            HttpContext.User.Claims.ToList()
               .ForEach(item => dict.Add(item.Type, item.Value));

            return Ok(dict);
        }

        [Authorize]
        [HttpGet]
        [Route("getteste")]
        public IActionResult Teste()
        {
            try
            {
                return Ok("Sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + "|" + e.InnerException);
            }
        }
    }
}
