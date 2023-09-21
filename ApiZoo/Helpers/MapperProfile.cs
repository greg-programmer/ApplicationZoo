using ApiZoo.DTOs;
using AutoMapper;
using ZooAPI.Models;

namespace ApiZoo.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();
            //cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()
        }
    }
}
