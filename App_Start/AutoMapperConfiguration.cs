using AutoMapper;
using PetOwner.Models.Entity;
using PetOwner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Owner, OwnerVM>()
                .ForMember(
                    e => e.Id,
                    opt => opt.MapFrom(
                        s => s.Id))
                .ForMember(
                    e => e.Name,
                    opt => opt.MapFrom(
                        s => s.Name))
               .ForMember(
                    e => e.Pets,
                    opt => opt.MapFrom(
                        s => s.Pets));

                config.CreateMap<Pet, PetVM>()
                 .ForMember(
                     e => e.Id,
                     opt => opt.MapFrom(
                         s => s.Id))
                 .ForMember(
                     e => e.Name,
                     opt => opt.MapFrom(
                         s => s.Name));

            });
        }
    }
}