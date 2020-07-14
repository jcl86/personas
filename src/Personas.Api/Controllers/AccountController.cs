using Microsoft.AspNetCore.Mvc;
using Personas.Domain;
using Personas.Shared;
using System.Threading.Tasks;

namespace Personas.Api
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly LoginService loginService;
        private readonly RegisterService registerService;

        public AccountController(LoginService loginService, RegisterService registerService)
        {
            this.loginService = loginService;
            this.registerService = registerService;
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
            var user = await registerService.Create(model.Username, model.Password);
            return Ok(new UserViewModel()
            {
                Id = user.Id,
                Username = user.ToString()
            });
        }
    }
}
