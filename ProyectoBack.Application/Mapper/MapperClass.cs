using AutoMapper;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Core.Entities.v1;


namespace ProyectoBack.Application.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {                        
            this.CreateMap<clsCompraDTO, clsCompra>();            
        }
    }
}
