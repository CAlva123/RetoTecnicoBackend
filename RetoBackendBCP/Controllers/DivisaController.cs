using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetoBackendBCP.Common;
using RetoBackendBCP.Entity.DTO;
using RetoBackendBCP.Entity.Model;
using RetoBackendBCP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DivisaController : ControllerBase
    {
        private readonly DivisaRepository divisaRepository;
        private readonly DivisaValidator divisaValidator;
        private readonly UpdateValidator updateValidator;
        public DivisaController(DivisaRepository divisaRepository, DivisaValidator divisaValidator, UpdateValidator updateValidator)
        {
            this.divisaValidator = divisaValidator;
            this.updateValidator = updateValidator;
            this.divisaRepository = divisaRepository;
        }

        [HttpGet("all")]
        public async Task<List<Divisa>> all()
        {
            return await divisaRepository.all();
        }
        [HttpPost("cambioDivisa")]
        public async Task<ActionResult<DivisaResponse>> find(DivisaRequest request)
        {
            var validation = divisaValidator.Validate(request);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            return await divisaRepository.find(request);
        }

        [HttpPost("updateTipoCambio")]
        public async Task<IActionResult> update(UpdateRequest request)
        {
            var validation = updateValidator.Validate(request);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            await divisaRepository.update(request);

            return Ok();
        }
    }
}
