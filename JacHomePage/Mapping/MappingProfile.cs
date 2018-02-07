using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JacHomePage.Controllers.Resources;
using JacHomePage.Models;

namespace JacHomePage.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //DOMAIN TO API
            CreateMap<Contact, ContactResource>()
                .ForMember(cr => cr.OfferResource, opt => opt.MapFrom(c => new OfferResource
                {
                    Name = c.Offer.Name
                }));
            CreateMap<Offer, OfferResource>();
            //API to DOMAIN
            CreateMap<ContactResource, Contact>();
            CreateMap<OfferResource, Offer>();

        }
    }
}
