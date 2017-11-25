using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ConstructionLK.DTOs;
using ConstructionLK.Models;

namespace ConstructionLK.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Mapper.CreateMap<Customer, CustomerDto>();
            //Domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<ServiceProvider, ServiceProviderDto>();
            Mapper.CreateMap<Item, ItemDto>();
            Mapper.CreateMap<ServiceProviderType, ServiceProviderTypeDto>();

            //Dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id,opt=>opt.Ignore());
            Mapper.CreateMap<ServiceProviderDto,ServiceProvider>();
            Mapper.CreateMap<ItemDto,Item>();
        }
    }
}