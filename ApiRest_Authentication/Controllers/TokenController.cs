using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiRest_Authentication.Models;
using ApiRest_Authentication.Helpers;

namespace ApiRest_Authentication.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (inputModel.Username != "basis" && inputModel.Password != "12345678")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                .AddSubject("james bond")
                                .AddIssuer("Fiver.Security.Bearer")
                                .AddAudience("Fiver.Security.Bearer")
                                .AddClaim("MembershipId", "111")
                                .AddExpiry(1)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}
