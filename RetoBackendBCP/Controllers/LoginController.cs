using Microsoft.AspNetCore.Mvc;
using RetoBackendBCP.Entity.Model;
using RetoBackendBCP.Repository;
using System;

namespace RetoBackendBCP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthServiceRepository _authServiceRepository;

        public LoginController(AuthServiceRepository authServiceRepository)
        {
            this._authServiceRepository = authServiceRepository;
        }


        [HttpPost]
        public ActionResult Token(UserLogin credenciales)
        {
            if (_authServiceRepository.ValidateLogin(credenciales.Username, credenciales.Password))
            {
                var fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromHours(6);
                var fechaExpiracion = fechaActual.Add(validez);

                var token = _authServiceRepository.GenerateToken(fechaActual, credenciales.Username, validez);
                return Ok(new
                {
                    Token = token,
                    ExpireAt = fechaExpiracion
                });
            }
            return StatusCode(401);
        }
    }
}
