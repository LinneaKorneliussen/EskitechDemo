using AutoMapper;
using EskitechDemo.DTOs;
using EskitechDemo.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping from Product to ProductDTO
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.Inventories, opt => opt.MapFrom(src => src.Inventories.Select(inv => new InventoryDTO
            {
                QuantityInStock = inv.QuantityInStock,
                Location = inv.Location
            }).ToList()));

        // Mapping from Inventory to InventoryDTO
        CreateMap<Inventory, InventoryDTO>();

        // Mapping from ProductDTO to Product (including Inventories)
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Inventories, opt => opt.MapFrom(src => src.Inventories.Select(inv => new Inventory
            {
                QuantityInStock = inv.QuantityInStock,
                Location = inv.Location
            }).ToList()));

        // Mapping from InventoryDTO to Inventory
        CreateMap<InventoryDTO, Inventory>();
    }
}
