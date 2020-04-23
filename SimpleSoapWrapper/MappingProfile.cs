using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SimpleSoapWrapper.Model;
using SoapDemoService;

namespace SimpleSoapWrapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonIdentification, SimplePerson>(); // Dead Simple Example

            // Slightly Configured Example
            CreateMap<Person, SimplePersonDetails>()
                .ForMember(dest => dest.FavoriteColors,
                    opt => opt.MapFrom(src => string.Join(", ", src.FavoriteColors)))
                .ForMember(dest => dest.HomeAddress,
                    opt => opt.MapFrom(src => $"{src.Home.Street}, {src.Home.City}, {src.Home.State} {src.Home.Zip}"))
                .ForMember(dest => dest.OfficeAddress,
                    opt => opt.MapFrom(src =>
                        $"{src.Office.Street}, {src.Office.City}, {src.Office.State} {src.Office.Zip}"));
        }
    }
}