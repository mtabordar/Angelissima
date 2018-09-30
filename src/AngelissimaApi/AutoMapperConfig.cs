namespace AngelissimaApi
{
    using System.Collections.Generic;
    using AutoMapper;
    using Models;
    using ViewModels;

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductViewModel, Product>()
                .ForMember(prod => prod.Id, options => options.MapFrom(pvm => pvm.ProductId));
          
            //CreateMap<ProductViewModel, Code>();
            //.ForMember(c => c.ProductId, options => options.MapFrom(pvm => pvm.ProductId))
            //.ForMember(c => c.BarCode, opt => opt.MapFrom(pvm => pvm.BarCodes.BarCode))
            //.ForMember(c => c.Product, opt => opt.Ignore());

            CreateMap<Product, ProductViewModel>()
                .ForMember(pvm => pvm.ProductId, options => options.MapFrom(prod => prod.Id));

            CreateMap<BarCode, BarCodeViewModel>().ReverseMap();

            CreateMap<InventoryItemViewModel, InventoryItem>()
                .ForMember(inv => inv.Id, options => options.Ignore())
                .ForMember(inv => inv.InventoryItemStatus, options => options.Ignore())
                .ForMember(inv => inv.InventoryItemStatusId, options => options.Ignore());

            CreateMap<InventoryItem, InventoryItemViewModel>()
                .ForMember(inv => inv.AvailableQuantity, options => options.Ignore())
                .ForMember(inv => inv.Quantity, options => options.Ignore());

            CreateMap<SaleViewModel, Sale>()
                .ForMember(sale => sale.Id, options => options.Ignore())
                .ForMember(sale => sale.SaleItems, options => options.UseValue(new List<SaleItem>()));

            //CreateMap<Sale, SaleViewModel>();

            //CreateMap<SaleItem, SaleItemViewModel>().ReverseMap();
        }
    }
}
