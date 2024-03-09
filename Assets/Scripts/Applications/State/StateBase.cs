using UniRx;
using VContainer;

namespace OskaKim.Applications.State
{
    public abstract class StateBase : IState
    {
        IState IState.NextState => _nextState;

        protected readonly IObjectResolver _parentResolver = null;
        protected readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private IState _nextState = null;

        protected StateBase(IObjectResolver parentResolver)
        {
            _parentResolver = parentResolver;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Update()
        {
        }

        // _compositeDisposableに登録された破棄処理を呼び出す
        public virtual void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        protected void SetNextStateWithoutReturnInfo<T>() where T : IState
        {
            _nextState = _parentResolver.Resolve<T>();
        }

        protected void SetNextState<T>() where T : IState
        {
            var stack = _parentResolver.Resolve<StateStack>();
            stack.Push(GetType());

            _nextState = _parentResolver.Resolve<T>();
        }

        protected void ReturnToPreviousState()
        {
            var stack = _parentResolver.Resolve<StateStack>();
            var backStateType = stack.Pop();

            _nextState = (IState)_parentResolver.Resolve(backStateType);
        }
    }
}
