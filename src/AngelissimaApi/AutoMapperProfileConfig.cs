namespace AngelissimaApi
{
    using AutoMapper;
    using AngelissimaApi.Models;
    using AngelissimaApi.ViewModels;

    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
