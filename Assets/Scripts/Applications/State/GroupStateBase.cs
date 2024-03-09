using OskaKim.Applications.State.Runner;
using VContainer;

namespace OskaKim.Applications.State
{
    public abstract class GroupStateBase : StateBase
    {
        protected GroupStateBase(IObjectResolver parentResolver) : base(parentResolver) { }

        protected StateRunner CreateStateRunner(IState startState)
        {
            var stateRunnerCreator = _parentResolver.Resolve<StateRunnerCreator>();

            var stateRunner = stateRunnerCreator.Create(startState);
            _compositeDisposable.Add(stateRunner);

            return stateRunner;
        }
    }
}
