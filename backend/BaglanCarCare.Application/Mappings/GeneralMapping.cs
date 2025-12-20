using AutoMapper;
using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Domain.Entities;
using BaglanCarCare.Domain.Entities.Catalog;
using System.Linq;

namespace BaglanCarCare.Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // --- EXPENSE (Gider) ---
            CreateMap<ExpenseRecord, ExpenseDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IsIncome ? 1 : 0));
            CreateMap<CreateExpenseDto, ExpenseRecord>()
                .ForMember(dest => dest.IsIncome, opt => opt.MapFrom(src => src.Type == 1));
            CreateMap<UpdateExpenseDto, ExpenseRecord>()
                .ForMember(dest => dest.IsIncome, opt => opt.MapFrom(src => src.Type == 1));

            // --- TRANSACTION (İşlem) ---
            CreateMap<ServiceTransaction, ServiceTransactionDto>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.ServiceDefinition != null ? src.ServiceDefinition.Name : "Özel İşlem"))
                .ForMember(dest => dest.VehiclePlate, opt => opt.MapFrom(src => src.Vehicle != null ? src.Vehicle.PlateNumber : ""))
                .ForMember(dest => dest.PersonnelNames, opt => opt.MapFrom(src =>
                    src.Personnels != null ? string.Join(", ", src.Personnels.Select(p => p.FirstName + " " + p.LastName)) : ""))
                .ReverseMap();

            CreateMap<CreateTransactionDto, ServiceTransaction>()
                .ForMember(dest => dest.TransactionItems, opt => opt.MapFrom(src => src.Items));

            CreateMap<TransactionItemDto, ServiceTransactionItem>().ReverseMap();

            // --- PERSONEL ---
            // --- PERSONEL (GÜNCELLENDİ) ---
            CreateMap<Personnel, PersonnelDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                    // İsim veya Soyisim null gelse bile patlamaz, boşlukları temizler.
                    ((src.FirstName ?? "") + " " + (src.LastName ?? "")).Trim()
                ))
                .ReverseMap();

            CreateMap<CreatePersonnelDto, Personnel>();
            CreateMap<UpdatePersonnelDto, Personnel>();

            // --- MATERIAL, VEHICLE, CUSTOMER (Diğerleri) ---
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<ServiceDefinition, ServiceDefinitionDto>().ReverseMap();
            CreateMap<CreateServiceDefDto, ServiceDefinition>();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<CreateVehicleDto, Vehicle>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>();

            // ==================================================================
            // YENİ KATALOG YAPISI (BURASI DÜZELTİLDİ)
            // ==================================================================

            // 1. Kategori
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            // 2. Ürün (Product)
            // 'CreateProductRequestDto' yerine 'CreateProductDto' kullanıyoruz
            CreateMap<CreateProductDto, Product>();

            // 'UpdateProductRequestDto' yerine 'UpdateProductDto' kullanıyoruz
            CreateMap<UpdateProductDto, Product>();

            // 'ProductDetailDto' yerine 'ProductListDto' kullanıyoruz (Listeleme için)
            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // 3. Varyant (Variant)
            CreateMap<CreateVariantDto, ProductVariant>();
            CreateMap<UpdateVariantDto, ProductVariant>();

            // 'VariantDto' yerine 'VariantListDto' kullanıyoruz
            CreateMap<ProductVariant, VariantListDto>();

            // 4. Parça Fiyat (PartPrice)
            CreateMap<CreatePartPriceDto, ProductPartPrice>()
                 .ForMember(dest => dest.ProductVariantId, opt => opt.MapFrom(src => src.VariantId));

            CreateMap<UpdatePartPriceDto, ProductPartPrice>()
                 .ForMember(dest => dest.ProductVariantId, opt => opt.MapFrom(src => src.VariantId));

            // Listeleme için
            CreateMap<ProductPartPrice, PartPriceDto>();
        }
    }
}