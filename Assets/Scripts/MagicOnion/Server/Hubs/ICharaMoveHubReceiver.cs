using System.Numerics;
using System.Threading.Tasks;

namespace GameServer.Hubs
{
    public interface ICharaMoveHubReceiver
    {
        /// <summary>
        /// 入室通知
        /// </summary>
        /// <param name="userName">ユーザー名</param>
        void OnJoin(string userName);

        /// <summary>
        /// 退出通知
        /// </summary>
        /// <param name="userName">ユーザー名</param>
        void OnLeave(string userName);
    }
}
