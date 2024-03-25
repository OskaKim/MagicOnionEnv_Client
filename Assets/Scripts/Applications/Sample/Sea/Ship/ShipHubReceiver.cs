using System;
using GameServer.Hubs;
using UniRx;

namespace OskaKim.Applications.Sample.Sea.Ship
{
    public class ShipHubReceiver : IShipHubReceiver
    {
        public IObservable<string> OnJoinAsObservable => _onJoinSubject;
        private readonly Subject<string> _onJoinSubject = new();

        public IObservable<string> OnLeaveAsObservable => _onLeaveSubject;
        private readonly Subject<string> _onLeaveSubject = new();

        public void OnJoin(string userName)
        {
            _onJoinSubject.OnNext(userName);
        }

        public void OnLeave(string userName)
        {
            _onLeaveSubject.OnNext(userName);
        }
    }
}
