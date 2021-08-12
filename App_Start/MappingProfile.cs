using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieApplication.Dtos;
using MovieApplication.Models;
namespace MovieApplication.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<MembershipType,MembershipTypeDto>();
            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
        

    }
}