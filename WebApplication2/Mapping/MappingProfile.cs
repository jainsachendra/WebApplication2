using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers.Resources;
using WebApplication2.Models;

namespace WebApplication2.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model , KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
           .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
           {
               Name
                 = v.ContactName,
               Email = v.ContactEmail,
               Phone = v.ContactPhone
           }))
            .ForMember(vr => vr.features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.make, opt => opt.MapFrom(v => v.model.Make))
                 .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                 {
                     Name
                 = v.ContactName,
                     Email = v.ContactEmail,
                     Phone = v.ContactPhone
                 }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new Feature { Id = vf.Feature.Id,Name=vf.Feature.Name }))) ;
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                //var removedFeatures = new List<VehicleFeature>();
                //foreach (var f in v.Features){
                //        if (!vr.features.Contains(f.FeatureId))
                //            removedFeatures.Add(f);
                //    }
                    var removedFeatures = v.Features.Where(f => !vr.features.Contains(f.FeatureId));
                    foreach (var f in removedFeatures) {
                        v.Features.Remove(f);
                    }
                    //foreach (var id in vr.features)
                    //{
                    //    if (!v.Features.Any(f => f.FeatureId == id))
                    //        v.Features.Add(new VehicleFeature { FeatureId = id });
                    //}
                    var addedfeature = vr.features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id });
                    foreach (var f in addedfeature)
                    {
                        v.Features.Add(f);
                    }
                }
                );
        }
    }
}
