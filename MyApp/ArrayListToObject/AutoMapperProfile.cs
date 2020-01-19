using System.Collections;
using AutoMapper;

namespace MyApp.ArrayListToObject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ArrayList, Fruit>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s[0]))
                .ForMember(d => d.Name, o => o.MapFrom(s => s[1]))
                .ForMember(d => d.Season, o => o.MapFrom(s => s[2]))
                .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s[3]))
                
                // 逆マップ
                .ReverseMap()
                .ConstructUsing(x => new ArrayList
                {
                    x.Id, x.Name, x.Season, x.UnitPrice
                });
        }
    }
}