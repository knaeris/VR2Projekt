using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VR2Identity.Models;
using VR2Identity.Models.AccountViewModels;

namespace VR2Identity.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Security")]
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public SecurityController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("getToken")]
        public async Task<IActionResult> GetToken([FromBody] LoginViewModel loginViewModel)
        {
            // check for user existance
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                // check for password validity
                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, loginViewModel.Password, false);
                if (result.Succeeded)
                {
                    var options = new IdentityOptions();

                    // add standard claims
                    var claims = new List<Claim>()
                    {
                        // subject
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        // unique id for this token
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        // as.net specific claims
                        // user id
                        new Claim(options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                        // user name
                        new Claim(options.ClaimsIdentity.UserNameClaimType, user.UserName),

                    };

                    // get all the misc claims for user and add them also
                    var userClaims = await _userManager.GetClaimsAsync(user);
                    claims.AddRange(userClaims);

                    // get and add the role and role claims
                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var userRole in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, userRole));
                        var role = await _userManager.FindByNameAsync(userRole);
                        if (role != null)
                        {
                            var roleClaims = await _userManager.GetClaimsAsync(role);
                            foreach (Claim roleClaim in roleClaims)
                            {
                                claims.Add(roleClaim);
                            }
                        }
                    }

                    // generate signing key
                    var key = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
                    // generate signing credentials
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        // issuer
                        _configuration["Token:Issuer"],
                        // audience
                        _configuration["Token:Issuer"],
                        // all the claims
                        claims,
                        // lifetime of the token
                        expires: DateTime.Now.AddMinutes(30),
                        // signature creation info
                        signingCredentials: creds
                        );

                    // resulting anonymous object, with base64 encoded jwt token
                    var res = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    };

                    // serialise result and return it
                    return Ok(res);
                }
            }
            return BadRequest("Could not create token");

        }
    }
}