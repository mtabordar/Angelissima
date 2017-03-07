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

            CreateMap<InventoryViewModel, Inventory>()
                .ForMember(inv => inv.Id, options => options.Ignore());

            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(inv => inv.TotalQuantity, options => options.Ignore()); ;

            CreateMap<SaleViewModel, Sale>()
                .ForMember(sale => sale.UpdatedAt, options => options.Ignore())
                .ForMember(sale => sale.Id, options => options.Ignore());

            CreateMap<Sale, SaleViewModel>();

            CreateMap<SaleItemViewModel, SaleItem>()
                .ForMember(si => si.SaleId, options => options.Ignore());

            CreateMap<SaleItem, SaleItemViewModel>().ReverseMap();
        }
    }
}
