namespace AngelissimaApi
{
    using AutoMapper;
    using Models;
    using ViewModels;

    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<ProductViewModel, Code>()
                .ForMember(cod => cod.BarCode, options => options.MapFrom(pvm => pvm.BarCode))
                .ForMember(cod => cod.ProductId, options => options.MapFrom(pvm => pvm.ProductId));

            CreateMap<ProductViewModel, Product>()
                .ForMember(prod => prod.Id, options => options.MapFrom(pvm => pvm.ProductId))
                .ForMember(prod => prod.UpdatedAt, options => options.Ignore())
                .ForMember(prod => prod.BarCode, options => options.MapFrom(pvm => Mapper.Map<ProductViewModel, Code>(pvm)));

            CreateMap<Product, ProductViewModel>()
                .ForMember(pvm => pvm.ProductId, options => options.MapFrom(prod => prod.Id))
                .ForMember(pvm => pvm.BarCode, options => options.MapFrom(prod => prod.BarCode.BarCode));

            CreateMap<InventoryViewModel, Inventory>().ReverseMap();
        }
    }
}
