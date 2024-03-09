using OskaKim.Applications.State;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample
{
    public class MainState : GroupStateBase
    {
        [Inject]
        public MainState(LifetimeScope parentLifetimeScope)
            : base(parentLifetimeScope.Container)
        {
        }

        public override void Initialize()
        {
            UnityEngine.Debug.Log("Main State Initialize");

            base.Initialize();
        }
    }
}
