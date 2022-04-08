
using AutoMapper;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBack.Application.Services.v1
{
    public class Servicio : IServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Servicio(IUnitOfWork unitOfWork, IMapper e)
        {
            _mapper = e;
            _unitOfWork = unitOfWork;
        }
        public async Task<clsCajera> obtenerVentasCajero(int idCajera)
        {
            var data = await _unitOfWork.IServicioRepository.obtenerVentasCajero(idCajera);
            return data;
        }
        public async Task<clsCompra> registrarCompra(List<clsCompraDTO> lsCompra, int idUsuario)
        {
            clsCompra compra = new clsCompra();
            compra.IdCajera = idUsuario;
            compra.PrecioTotal = 0;
            if (lsCompra != null)
            {
                List<clsProductosCompra> productosComprados = new List<clsProductosCompra>();
                foreach (var item in lsCompra)
                {
                    var dataProducto = _unitOfWork.clsProductos.GetById(item.idProducto).Result;
                    if (dataProducto == null) throw new Exception($"El producto {item.idProducto } no existe");
                    var producto = productosComprados.Where(a => a.IdProducto == item.idProducto).FirstOrDefault();
                    if (producto != null)
                    {
                        producto.Cantidad = producto.Cantidad + item.cantidad;
                    }
                    else
                    {
                        productosComprados.Add(new clsProductosCompra()
                        {
                            IdProducto = item.idProducto,
                            Cantidad = item.cantidad,
                            fechaCreacion = DateTime.Now
                        });
                    }
                    compra.PrecioTotal = compra.PrecioTotal + (item.cantidad * dataProducto.Precio);
                }
                compra.fechaCreacion = DateTime.Now;
                compra.clsProductosCompra = productosComprados;
                compra.PrecioTotal = (decimal)System.Math.Round(compra.PrecioTotal, 2);
                await _unitOfWork.clsCompra.Add(compra);
                await _unitOfWork.SaveChangesAsync();
                return compra;
            }
            return null;
            
        }


        public async Task<clsUsuario> crearUsuario(clsUsuarioDTO login)
        {
            var usuarioExistente = await _unitOfWork.IServicioRepository.obtenerUsuarios(login.usuario);
            if (usuarioExistente != null) throw new Exception("El usuario ya existe");
            var cajero = await _unitOfWork.IServicioRepository.obtenerCajero(login.idCajero);
            if (cajero == null) throw new Exception("El cajero/a no existe");
            var cajeroUsuario = await _unitOfWork.IServicioRepository.obtenerCajeroUsuario(login.idCajero);
            if (cajeroUsuario != null) throw new Exception("El cajero/a ya tiene un usuario de sistema");
            clsUsuario clsUsuario = new clsUsuario();
            var password = PasswordHash(login.password);
            clsUsuario.password = password;
            clsUsuario.usuario = login.usuario;
            clsUsuario.idCajero = login.idCajero;
            clsUsuario.fechaCreacion = DateTime.Now;
            await _unitOfWork.clsUsuario.Add(clsUsuario);
            await _unitOfWork.SaveChangesAsync();
            return clsUsuario;
        }
        private static string PasswordHash(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("x3")));
        }
        public async Task<clsUsuario> obtenerUsuario(string usuario, string password)
        {

            var usu = await _unitOfWork.IServicioRepository.obtenerUsuarios(usuario);
            if (usu != null)
            {
                var passwordhash = PasswordHash(password);
                if (usu.password == passwordhash)
                {
                    return usu;
                }
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
