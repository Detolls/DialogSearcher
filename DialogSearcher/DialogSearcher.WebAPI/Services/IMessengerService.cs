namespace DialogSearcher.WebAPI.Services;

public interface IMessengerService
{
    Guid SearchDialogByClientIds(Guid[] clientIds);
}