using AutoMapper;
using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;

namespace DotNetTraining_Assignments3
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();                
            });
            return mappingConfig;
        }
    }
}
