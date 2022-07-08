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
            .Where(group => clientIds.Length == group.Count() 
                && !clientIds.Except(group.Select(item => item.IDClient)).Any()).Select(group => group.Key)
            .ToList();
        
        return result.Count == 1 ? result.First() : Guid.Empty;
    }
}