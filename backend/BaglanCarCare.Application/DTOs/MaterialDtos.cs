namespace BaglanCarCare.Application.DTOs
{
    public class CreateMaterialDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string QualityGrade { get; set; }
        public int WarrantyYears { get; set; }
        public string Thickness { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMaterialDto : CreateMaterialDto
    {
        public int Id { get; set; }
    }

    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string QualityGrade { get; set; }
        public int WarrantyYears { get; set; }
        public string FullInfo => $"{Name} ({QualityGrade})";
    }
}