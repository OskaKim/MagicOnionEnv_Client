using System.Threading;
using Cysharp.Threading.Tasks;
using GameServer.Hubs;
using MagicOnion.Client;

namespace OskaKim.Applications.Sample.Sea.Ship
{
    public class ShipHubController
    {
        private CancellationTokenSource shutdownCancellation = new CancellationTokenSource();
        private IShipHub streamingClient;

        public async UniTask JoinAsync(string userName, IShipHubReceiver targetShipHubReceiver)
        {
            UnityEngine.Debug.Log($"Join Start{userName}");

            var channel = OskaKim.Definitions.Sample.ServerDefinitions.GetChannelX();
            streamingClient = await StreamingHubClient.ConnectAsync<IShipHub, IShipHubReceiver>(channel, targetShipHubReceiver, cancellationToken: shutdownCancellation.Token);
            await streamingClient.JoinAsync("move", userName);
        }

        public async UniTask LeaveAsync()
        {
            if (streamingClient is null) return;

            await streamingClient.LeaveAsync();
        }
    }
}
