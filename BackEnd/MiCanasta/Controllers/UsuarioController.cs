﻿using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;


        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> GetById(String id)
        {
            return _usuarioService.GetById(id);
        }

        /// <summary>
        /// Realiza la funcion de loguear y registrar
        /// Los Parametros van dentro del cuerpo.
        /// </summary>
        /// <param Dni="12345678"></param>
        /// <param Contrasena="12345678"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UsuarioAccesoDto> ValidarIngreso([FromBody] UsuarioLoginDto UsuarioLogin)
        {
            UsuarioAccesoDto usuario = _usuarioService.ValidateLogin(UsuarioLogin.Dni, UsuarioLogin.Contrasena);
            if (usuario.Dni == "NotFound")
            {
                return Unauthorized(ConstanteException.UsuarioLoginIncorrectoException);
            } else if (usuario.Dni == "NotExist")
            {
                return NotFound(ConstanteException.UsuarioLoginInexistenteException);
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(String id)
        {
            _usuarioService.Remove(id);
            return Ok();
        }
    }
}
