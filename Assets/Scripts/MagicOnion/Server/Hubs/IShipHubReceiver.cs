namespace GameServer.Hubs
{
    public interface IShipHubReceiver
    {
        void OnJoin(string userName);

        void OnLeave(string userName);
    }
}
