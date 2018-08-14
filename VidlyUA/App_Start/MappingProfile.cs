using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyUA.Dtos;
using VidlyUA.Models;

namespace VidlyUA.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //
            // *IMPORTANT* //
            //  When going from a dto (Data Transfer Object) to a Model object
            //  opt.Ignore ensures that id is not set during a Mapping.
            //  ID should aways be uniqe so it should not be mapped.
            //
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}