using DialogSearcher.WebAPI.Models;

namespace DialogSearcher.WebAPI.Services;

public class MessengerService : IMessengerService
{
    public Guid SearchDialogByClientIds(Guid[] clientIds)
    {
        var model = new RGDialogsClients();
        List<RGDialogsClients> clientDialogs = model.Init();

        var groupedClientDialogs = clientDialogs.GroupBy(x => x.IDRGDialog);
        var result = groupedClientDialogs
                .SingleOrDefault(group => !clientIds.Except(group.Select(item => item.IDClient)).Any())?.Key
                ?? Guid.Empty;
        
        return result;
    }
}