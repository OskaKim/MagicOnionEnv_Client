using System;

namespace OskaKim.Applications.State.Runner
{
    public class StateRunner : IDisposable
    {
        private class FirstState : IState
        {
            public IState NextState => _state;

            private readonly IState _state;

            public FirstState(IState state)
            {
                _state = state;
            }

            public void Initialize() { }
            public void Update() { }
            public void Dispose() { }
        }

        protected IState _state = null;

        public StateRunner(IState startState)
        {
            _state = new FirstState(startState);
        }

        public virtual void Update()
        {
            _state.Update();

            if (_state.NextState != null)
            {
                var nextState = _state.NextState;

                _state.Dispose();

                _state = nextState;

                _state.Initialize();
            }
        }

        public virtual void Dispose()
        {
            _state.Dispose();
        }
    }
}
