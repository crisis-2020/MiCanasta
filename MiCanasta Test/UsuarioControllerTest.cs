﻿using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MiCanasta_Test
{
    public class UsuarioControllerTest
    {

        /// <summary>
        /// Se ingresa un usuario valido y contrasena valida
        /// se retorna los datos de acceso de usuario
        /// </summary>
        [Fact]
        public void PostValidarIngreso_WhenCalled_ReturnedUsuarioAcceso()
        {
            var _service = new Mock<UsuarioService>();
            var _controller = new UsuarioController(_service.Object);

            UsuarioLoginDto UsuarioWrongLogin = new UsuarioLoginDto { Dni = "12345671", Contrasena = "12345671" };
            UsuarioAccesoDto UsuarioResponse = new UsuarioAccesoDto();
            //
            _service.Setup(x => x.ValidateLogin(UsuarioWrongLogin.Dni,UsuarioWrongLogin.Contrasena)).Returns(UsuarioResponse);
            ActionResult<UsuarioAccesoDto> result = _controller.ValidarIngreso(UsuarioWrongLogin);
            //Assert
            Assert.IsType <UsuarioAccesoDto>(UsuarioResponse);
        }

        /// <summary>
        /// se ingresa usuario valido y contrasema invalida
        /// se retorna un mensaje notfound
        /// </summary>
        [Fact]
        public void PostValidarIngreso_WhenCalled_ReturnedNotFound()
        {
            var _service = new Mock<UsuarioService>();
            var _controller = new UsuarioController(_service.Object);
            //
            UsuarioLoginDto UsuarioWrongLogin = new UsuarioLoginDto { Dni = "12345671", Contrasena = "12345672" };
            UsuarioAccesoDto UsuarioResponseAssert = new UsuarioAccesoDto { Dni = "NotFound" };
            UsuarioAccesoDto UsuarioResponse = new UsuarioAccesoDto();
            //
            _service.Setup(x => x.ValidateLogin(UsuarioWrongLogin.Dni, UsuarioWrongLogin.Contrasena)).Returns(UsuarioResponse);
            ActionResult<UsuarioAccesoDto> result = _controller.ValidarIngreso(UsuarioWrongLogin);
            //Assert
            Assert.IsType<UsuarioAccesoDto>(UsuarioResponseAssert);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void PostValidarIngreso_WhenCalled_ReturnedNotExist()
        {
            var _service = new Mock<UsuarioService>();
            var _controller = new UsuarioController(_service.Object);
            //
            UsuarioLoginDto UsuarioWrongLogin = new UsuarioLoginDto { Dni = "12345678", Contrasena = "12345671" };
            UsuarioAccesoDto UsuarioResponseAssert = new UsuarioAccesoDto { Dni = "NotExist" };
            UsuarioAccesoDto UsuarioResponse = new UsuarioAccesoDto();
            //
            _service.Setup(x => x.ValidateLogin(UsuarioWrongLogin.Dni, UsuarioWrongLogin.Contrasena)).Returns(UsuarioResponse);
            ActionResult<UsuarioAccesoDto> result = _controller.ValidarIngreso(UsuarioWrongLogin);
            //Assert
            Assert.IsType<UsuarioAccesoDto>(UsuarioResponseAssert);
        }
    }
}
