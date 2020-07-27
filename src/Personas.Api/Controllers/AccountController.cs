using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personas.Domain;
using Personas.Shared;
using System;
using System.Threading.Tasks;

namespace Personas.Api
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly LoginService loginService;
        private readonly RegisterService registerService;
        private readonly PasswordChanger passwordChanger;

        public AccountController(LoginService loginService, RegisterService registerService, PasswordChanger passwordChanger)
        {
            this.loginService = loginService;
            this.registerService = registerService;
            this.passwordChanger = passwordChanger;
        }

        /// <summary>
        /// Genera un token con caducidad de 7 días para ese usuario y contraseña
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Devuelve el token creado cuando la autenticación es correcta</response>
        /// <response code="401">Si falla la utenticación</response>   
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationSuccessResponse>> Authenticate(AuthenticateModel model)
        {
            string token = await loginService.GetAuthenticationToken(model.Username, model.Password);

            return Ok(new AuthenticationSuccessResponse()
            {
                Username = model.Username,
                Token = token
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> Register(RegisterModel model)
        {
            var user = await registerService.CreateUser(model.Username, model.Password);
            return Ok(new UserViewModel()
            {
                Id = user.Id,
                Username = user.ToString(),
                Roles = user.Roles
            });
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> UpdatePassword(ChangePasswordModel model)
        {
            var currentUser = Guid.Parse(User.GetUserId());
            await passwordChanger.Change(currentUser, model.Email, model.CurrentPassword, model.NewPassword);
            return NoContent();
        }
    }
}
