using AutoMapper;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.DTO;

namespace FunBooksAndVideos.MappingProfiles
{
    public class CustomerResponsePofile : Profile
    {
        public CustomerResponsePofile()
        {
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
        }

    }

    public class CustomerRequestPofile : Profile
    {
        public CustomerRequestPofile()
        {
            CreateMap<Customer, AddCustomerDTO>().ReverseMap();
        }

    }

    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<Membership, MembershipDTO>().ReverseMap();
        }

    }

    public class PurchaseOrderResponseProfile : Profile
    {
        public PurchaseOrderResponseProfile()
        {
            CreateMap<PurchaseOrder, PurchaseOrderResponseDTO>().ReverseMap();
        }

    }

    public class PurchaseOrderRequestProfile : Profile
    {
        public PurchaseOrderRequestProfile()
        {
            CreateMap<PurchaseOrder, PurchaseOrderRequestDTO>().ReverseMap();
        }

    }

    public class ItemResponseProfile : Profile
    {
        public ItemResponseProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
        }

    }

    public class ItemIdProfile : Profile
    {
        public ItemIdProfile()
        {
            CreateMap<Item, ItemIdDTO>().ReverseMap();
        }

    }

    public class AddItemProfile : Profile
    {
        public AddItemProfile()
        {
            CreateMap<Item, AddItemDTO>().ReverseMap();
        }

    }

    public class ShippingSlipProfile : Profile
    {
        public ShippingSlipProfile()
        {
            CreateMap<ShippingSlip, ShippingSlipDTO>().ReverseMap();
        }

    }
}