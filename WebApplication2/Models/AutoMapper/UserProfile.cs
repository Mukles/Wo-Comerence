using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Account;
using WebApplication2.Models._Product;
using WebApplication2.ViewModel.Account;

namespace Wocomerce.Models.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, Register>();
            CreateMap<LogInModel, Login>();
            CreateMap<AddProduct, Products>()
            .ForMember(des => des.photos, act => act.Ignore())
            .ForMember(des =>des.ProductImage, act => act.Ignore())
            .ReverseMap();
        }
    }
}


// new Comment