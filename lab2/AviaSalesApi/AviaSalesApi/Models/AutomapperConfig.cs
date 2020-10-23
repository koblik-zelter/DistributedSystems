﻿using System;
using AutoMapper;
using AviaSalesApi.Data.Entities;
using AviaSalesApi.Models.Tickets;
using AviaSalesApi.Models.Warrants;
using Newtonsoft.Json;

namespace AviaSalesApi.Models
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Ticket1, TicketModel>()
                .ForMember(dest => dest.TransitPlaces,
                    opt => opt.Ignore())
                .ForMember(dest => dest.TakeOffDay, opt => opt.MapFrom(
                    src => new DateTime(src.TakeOffYear, src.TakeOffMonth, src.TakeOffDay)));
            
            CreateMap<TicketById, TicketModel>()
                .ForMember(dest => dest.TransitPlaces,
                    opt => opt.MapFrom(
                        src => JsonConvert.DeserializeObject<TransitPlace[]>(src.TransitPlaces)))
                .ForMember(dest => dest.TakeOffDay, opt => opt.MapFrom(
                    src => new DateTime(src.TakeOffYear, src.TakeOffMonth, src.TakeOffDay)));

            CreateMap<WarrantByPassengerIban, WarrantModel>();
            CreateMap<WarrantByPassengerIbanAndTicketId, WarrantModel>();
            CreateMap<WarrantCreateUpdateModel, WarrantByPassengerIban>();
            CreateMap<WarrantCreateUpdateModel, WarrantByPassengerIbanAndTicketId>();
        }
    }
}