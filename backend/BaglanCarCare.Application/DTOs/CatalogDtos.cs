namespace BaglanCarCare.Application.DTOs
{
    // --- KATEGORİ ---
    public class CategoryDto { public int Id { get; set; } public string Name { get; set; } public string Description { get; set; } }
    public class CreateCategoryDto { public string Name { get; set; } public string Description { get; set; } }
    public class UpdateCategoryDto { public int Id { get; set; } public string Name { get; set; } public string Description { get; set; } }

    // --- ÜRÜN (LEVEL 1) ---
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public bool HasMicron { get; set; }
        public decimal BasePrice { get; set; }
        public List<VariantListDto> Variants { get; set; } // İç içe liste
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool HasMicron { get; set; } // True ise fiyat 0 gönderilmeli veya backend 0 yapmalı
        public decimal BasePrice { get; set; }
    }

    public class UpdateProductDto : CreateProductDto
    {
        public int Id { get; set; }
    }

    // --- VARYANT / MİKRON (LEVEL 2) ---
    public class VariantListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThicknessCode { get; set; }
        public bool HasSubParts { get; set; }
        public decimal VariantPrice { get; set; }
        public List<PartPriceDto> PartPrices { get; set; }
    }

    public class CreateVariantDto
    {
        public int ProductId { get; set; } // Hangi ürüne bağlı
        public string Name { get; set; }
        public string ThicknessCode { get; set; }
        public bool HasSubParts { get; set; }
        public decimal VariantPrice { get; set; }
    }

    public class UpdateVariantDto : CreateVariantDto
    {
        public int Id { get; set; }
    }

    // --- PARÇA FİYAT (LEVEL 3) ---
    public class PartPriceDto
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public decimal Price { get; set; }
        public bool IsExtra { get; set; }
    }

    public class CreatePartPriceDto
    {
        public int VariantId { get; set; } // Hangi varyanta bağlı
        public string PartName { get; set; }
        public decimal Price { get; set; }
        public bool IsExtra { get; set; }
    }

    public class UpdatePartPriceDto : CreatePartPriceDto
    {
        public int Id { get; set; }
    }
}