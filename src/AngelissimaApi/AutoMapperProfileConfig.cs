namespace AngelissimaApi
{
    using AutoMapper;
    using Models;
    using ViewModels;

    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<ProductViewModel, Product>()
                .ForMember(prod => prod.Id, options => options.MapFrom(pvm => pvm.ProductId))
                .ForMember(prod => prod.UpdatedAt, options => options.Ignore());

            CreateMap<Product, ProductViewModel>()
                .ForMember(pvm => pvm.ProductId, options => options.MapFrom(prod => prod.Id));

            CreateMap<Code, BarCodeViewModel>().ReverseMap();

            CreateMap<InventoryViewModel, Inventory>().ReverseMap();
        }
    }
}
