using DC_Modelo_Arana_Core.CustomEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoBack.Application.DTOs.v1;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.Helpers;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBack.Controllers.v1
{
    [Produces("application/json")]
    [Route("api/v1/servicio")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicio _services;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioController(IServicio a, IConfiguration e, IUnitOfWork t)
        {
            _unitOfWork = t;
            _configuration = e;
            _services = a;
        }
        ///<summary>
        ///Endpoint obtener maestra productos
        ///</summary>
        [HttpGet("obtenerProductos")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerProductos()
        {
            try
            {
                var data = _unitOfWork.clsProductos.GetAll().ToList();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint registrar maestra productos
        ///</summary>
        [HttpPost("registrarProductos")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerTiposDocumento([FromBody] clsProductos prod)
        {
            try
            {
                await _unitOfWork.clsProductos.Add(prod);
                await _unitOfWork.SaveChangesAsync();
                return Ok(prod);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint obtener maestra tipo de documentos
        ///</summary>
        [HttpGet("obtenerTiposDocumento")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerTiposDocumento()
        {
            try
            {
                var data = _unitOfWork.clsTipoDocumento.GetAll().ToList();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint registrar tipos de documento
        ///</summary>
        [HttpPost("registrarTipoDocumento")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerTiposDocumento([FromBody] clsTipoDocumento doc)
        {
            try
            {
                await _unitOfWork.clsTipoDocumento.Add(doc);
                await _unitOfWork.SaveChangesAsync();
                return Ok(doc);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint obtener las ventas hechas por un cajero/a por su ID
        ///</summary>
        [HttpGet("obtenerVentasCajero/{id}")]
        [Authorize(Policy = "obtenerServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerVentasCajero(int id)
        {
            try
            {
                var data = await _services.obtenerVentasCajero(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint registrar compra
        ///</summary>
        [HttpPost("registrarCompra")]
        [Authorize(Policy = "crearServicio")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> registrarCompra([FromBody] List<clsCompraDTO> compra)
        {
            try
            {
                string idUsuario = User.Claims.FirstOrDefault(x => x.Type == "idCajero").Value;
                var data = await _services.registrarCompra(compra, Convert.ToInt32(idUsuario));
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
        ///<summary>
        ///Endpoint crear usuario de sistema
        ///</summary>
        [HttpPost("crear_usuario")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> crearUsuario([FromBody] clsUsuarioDTO login)
        {
            try
            {
                var data = await _services.crearUsuario(login);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        ///<summary>
        ///Endpoint Login al sistema
        ///</summary>

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult<IActionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> obtenerEmpleados([FromBody] LoginModelDTO login)
        {
            try
            {
                var data = await _services.obtenerUsuario(login.usuario, login.password);
                if (data != null)
                {
                    string secret = _configuration.GetValue<string>("KeySecret");
                    var jwtHelper = new JWT(secret);
                    List<string> listaToken = new List<string>() { "crearServicio", "obtenerServicio", "actualizarServicio", "eliminarServicio" };

                    var token = jwtHelper.crearToken(data.idCajero, listaToken);
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "logeado",
                        token = token
                    });
                }
                else
                {
                    return BadRequest("Usuario o contraseña incorrecta");
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

    }
}
