using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Authors
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }
    }
}