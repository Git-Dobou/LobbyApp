using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Interfaces;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace App.Controllers {
    [Route ("api/[controller]")]
    public class LoginController : Controller {
        private readonly ILoginService _loginService;
        private readonly IMemberService _memberService;
        public LoginController (ILoginService loginService, IMemberService memberService) {
            _memberService = memberService;
            _loginService = loginService;
        }

        [HttpPost ("[action]")]
        public IActionResult LoginMember ([FromBody] Member member) {
            if (member == null) {
                return BadRequest ("Invalid client request");
            }

            if (member.UserName == "Daniel486" && member.PassWord == "test") {
                var secretKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("superSecretKey@345"));
                var signinCredentials = new SigningCredentials (secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim> {
                    new Claim (ClaimTypes.Name, member.UserName),
                    new Claim (ClaimTypes.Role, "Manager")
                };

                var tokeOptions = new JwtSecurityToken (
                    issuer: "http://localhost:1996",
                    audience: "http://localhost:1996",
                    claims : claims,
                    expires : DateTime.Now.AddMinutes (5),
                    signingCredentials : signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler ().WriteToken (tokeOptions);
                return Ok (new { Token = tokenString });
            } else {
                return Unauthorized ();
            }
        }
    }
}