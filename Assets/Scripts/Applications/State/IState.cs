using System;

namespace OskaKim.Applications.State
{
    public interface IState : IDisposable
    {
        IState NextState { get; }

        void Initialize();

        void Update();
    }
}
