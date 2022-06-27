using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebTest.Models;
using WebTestDAL.Entities;

namespace WebTestBL.Profiles
{
    public class BodyKitProfile : Profile
    {
        public BodyKitProfile()
        {
            CreateMap<BodyKit, BodyKitDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FrontBumper, opt => opt.MapFrom(src => src.FrontBumper))
                .ForMember(dest => dest.RearBumper, opt => opt.MapFrom(src => src.RearBumper))
                .ForMember(dest => dest.SideSkirts, opt => opt.MapFrom(src => src.SideSkirts))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version));

            CreateMap<BodyKitDto, BodyKit>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FrontBumper, opt => opt.MapFrom(src => src.FrontBumper))
                .ForMember(dest => dest.RearBumper, opt => opt.MapFrom(src => src.RearBumper))
                .ForMember(dest => dest.SideSkirts, opt => opt.MapFrom(src => src.SideSkirts))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version));
        }
    }
}
