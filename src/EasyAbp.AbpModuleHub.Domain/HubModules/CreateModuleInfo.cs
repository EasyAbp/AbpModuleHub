using System;

namespace EasyAbp.AbpModuleHub.HubModules;

public class CreateModuleInfo
{
    public string Name { get; set; }

    public string CoverUrl { get; set; }

    public string Description { get; set; }

    public string PayMethod { get; set; }

    public decimal Price { get; set; }

    public Guid? ModuleTypeId { get; set; }
        
    public Guid AuthorId { get; set; }

    public CreateModuleInfo(string name, string description, string payMethod, decimal price, Guid? moduleTypeId,
        string coverUrl, Guid authorId)
    {
        Name = name;
        Description = description;
        PayMethod = payMethod;
        Price = price;
        ModuleTypeId = moduleTypeId;
        CoverUrl = coverUrl;
        AuthorId = authorId;
    }
}