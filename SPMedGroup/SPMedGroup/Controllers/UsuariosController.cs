﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.Domains;
using SPMedGroup.Interfaces;
using SPMedGroup.Repositories;

namespace SPMedGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("Prontuario")]
        public IActionResult CadastrarProntuario(ProntuarioPaciente prontuario)
        {
            try
            {
                UsuarioRepository.CadastrarProntuario(prontuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarMedico")]
        public IActionResult ListarMedicos()
        {
            try
            {                
                return Ok(UsuarioRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPaciente")]
        public IActionResult ListarPacientes()
        {
            try
            {
                return Ok(UsuarioRepository.ListarPacientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}