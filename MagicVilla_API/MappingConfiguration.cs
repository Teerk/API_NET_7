using AutoMapper;
using MagicVilla_API.Modelos;

namespace MagicVilla_API
{
    public class MappingConfiguration:Profile
    {

        public MappingConfiguration()
        {
            CreateMap<Villa, VillaDTO>();                
            CreateMap<VillaDTO, Villa>();    
            
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();                
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();          
            

        }
    }
}
