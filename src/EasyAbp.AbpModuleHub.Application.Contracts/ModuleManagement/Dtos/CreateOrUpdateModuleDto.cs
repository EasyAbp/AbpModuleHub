namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public abstract class CreateOrUpdateModuleDto
    {
        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public string PayMethod { get; set; }

        public double Price { get; set; }
    }
}