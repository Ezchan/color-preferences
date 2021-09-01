using AutoMapper;
using colors.Controllers.Resources;
using colors.Models;
using System;

namespace colors.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
          // API Resource to Domain
          CreateMap<EntryResource, Entry>().ForMember(e => e.FirstName, opt => opt.MapFrom(er => er.FirstName)).ForMember(e => e.LastName, opt => opt.MapFrom(er => er.LastName)).ForMember(e => e.Age, opt => opt.MapFrom(er => Int32.Parse(er.Age.ToString()))).ForMember(e => e.Color, opt => opt.MapFrom(er => er.Color.ToLower()));
        }
    }
}