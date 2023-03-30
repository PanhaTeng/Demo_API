using AutoMapper;
using Demo_API.Model;
using Demo_API.Model.Dto;

namespace Demo_API.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyDtoCreate, Company>().ReverseMap();
            CreateMap<CompanyDtoUpdate, Company>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerUpdate, Customer>().ReverseMap();
            CreateMap<InvoiceDto, Invoice>().ReverseMap();
            CreateMap<InvoiceUpdate, Invoice>().ReverseMap();
        }
    }
}
