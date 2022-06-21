using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.Authors;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace EasyAbp.AbpModuleHub.EventHandles;

public class IdentityUserChangedEventHandler : ILocalEventHandler<EntityCreatedEventData<IdentityUser>>,
    ILocalEventHandler<EntityDeletedEventData<IdentityUser>>,
    ITransientDependency
{
    private readonly IAuthorRepository _authorRepository;

    public IdentityUserChangedEventHandler(IGuidGenerator guidGenerator,
        IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task HandleEventAsync(EntityCreatedEventData<IdentityUser> eventData)
    {
        await _authorRepository.InsertAsync(new Author(eventData.Entity.Id,
            eventData.Entity.UserName,
            eventData.Entity.Email));
    }

    public Task HandleEventAsync(EntityDeletedEventData<IdentityUser> eventData)
    {
        // TODO: Clear user-related data.

        return Task.CompletedTask;
    }
}