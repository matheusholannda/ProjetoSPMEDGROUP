using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.Domains;
using SPMedGroup.Interfaces;
using SPMedGroup.Repositories;
using SPMedGroup.Util;

namespace SPMedGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultasRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Cadastrar (Consultas consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);

                Consultas consultas = ConsultaRepository.BuscarPorId(consulta.Id);

                Util.SendGrid Email = new Util.SendGrid();

                Email.Enviar(consultas.IdProntuarioNavigation.IdUsuarioNavigation.Email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        public IActionResult Atualizar (Consultas consulta)
        {
            try
            {
                ConsultaRepository.Atualizar(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                string Role = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                
                if (Role == "MEDICO")
                {
                    return Ok(ConsultaRepository.ListarConsultasMed(id));
                }
                else if (Role == "PACIENTE")
                {
                    return Ok(ConsultaRepository.ListarConsultasPac(id));
                }
                else
                {
                    return Ok(ConsultaRepository.ListarConsultas());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}