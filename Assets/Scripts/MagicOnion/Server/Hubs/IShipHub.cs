using MagicOnion;
using System.Threading.Tasks;

namespace GameServer.Hubs
{

    public interface IShipHub : IStreamingHub<IShipHub, IShipHubReceiver>
    {
        Task JoinAsync(string roomName, string userName);
        Task LeaveAsync();
        Task SendMessageAsync(string userName, string message);
    }
}
