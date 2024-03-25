using OskaKim.Applications.State;
using VContainer;
using VContainer.Unity;

namespace OskaKim.Applications.Sample.Sea
{
    public class SeaFinishActionState : StateBase
    {
        [Inject]
        public SeaFinishActionState(LifetimeScope parentLifetimeScope)
            : base(parentLifetimeScope.Container)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            UnityEngine.Debug.Log("해전 종료");
        }
    }
}
