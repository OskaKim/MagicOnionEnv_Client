using System.Collections.Generic;
using Grpc.Core;
using GameServer.Hubs;
using MagicOnion.Client;
using MagicOnion;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class CharaMoveApp : MonoBehaviour, ICharaMoveHubReceiver
{
    [SerializeField] GameObject charaPrefab;

    private CancellationTokenSource shutdownCancellation = new CancellationTokenSource();
    private ChannelBase channel;
    private ICharaMoveHub streamingClient;
    private Dictionary<string, GameObject> charas = new Dictionary<string, GameObject>();

    public void OnJoin(string userName)
    {
        if (charas.ContainsKey(userName)) return;

        charas[userName] = Instantiate(charaPrefab);
        charas[userName].name = userName;
    }

    public void OnLeave(string userName)
    {
        if (charas.TryGetValue(userName, out var targetChara))
        {
            targetChara.gameObject.SetActive(false);
        }
    }

    public async Task JoinMoveArea(string userName)
    {
        await OnJoinMoveArea(userName);
    }

    private async Task OnJoinMoveArea(string userName)
    {
        // サーバーへ接続
        channel = GrpcChannelx.ForAddress("http://192.168.10.120:5001");
        streamingClient = await StreamingHubClient.ConnectAsync<ICharaMoveHub, ICharaMoveHubReceiver>(channel, this, cancellationToken: shutdownCancellation.Token);

        var createdCharas = await streamingClient.JoinAsync("move", userName);
        foreach (var createdChara in createdCharas)
        {
            (this as ICharaMoveHubReceiver).OnJoin(createdChara);
        }
    }
}
