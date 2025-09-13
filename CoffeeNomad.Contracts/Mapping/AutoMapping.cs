using AutoMapper;
using CoffeeNomad.Contracts.Contracts;
using CoffeeNomad.Contracts.DTOs;
using CoffeeNomad.DataBase.Entities;

namespace CoffeeNomad.Contracts.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            this.CreateMap<LoginContract, User>();
            this.CreateMap<RegisterContract, User>();
            this.CreateMap<ProductMenu, ProductByList>();
            this.CreateMap<ProductByList, ProductMenu>();
        }
    }
}
