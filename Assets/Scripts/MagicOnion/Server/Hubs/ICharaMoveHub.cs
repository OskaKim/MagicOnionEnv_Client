using MagicOnion;
using System.Threading.Tasks;

namespace GameServer.Hubs
{
    public interface ICharaMoveHub : IStreamingHub<ICharaMoveHub, ICharaMoveHubReceiver>
    {
        /// <summary>
        /// 入室通知
        /// </summary>
        /// <param name="roomName">ルーム名</param>
        /// <param name="userName">ユーザー名</param>
        /// <returns></returns>
        Task<string[]> JoinAsync(string roomName, string userName);

        /// <summary>
        /// 退室通知
        /// </summary>
        /// <returns></returns>
        Task LeaveAsync();
    }
}
