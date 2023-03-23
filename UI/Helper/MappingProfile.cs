using AutoMapper;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PFSDA.Models.Customers, Customers>()
                .ForMember(des => des.CustomerID, act => act.MapFrom(src => src.CustomerID))
                .ForMember(des => des.CustomerNumber, act => act.MapFrom(src => src.CustomerNumber))
                .ForMember(des => des.CustomerName, act => act.MapFrom(src => src.CustomerName))
                .ForMember(des => des.CustomerMainID, act => act.MapFrom(src => src.CustomerMainID))
                .ForMember(des => des.UpdateBy, act => act.MapFrom(src => src.CreatedTime));
        }
    }
}
