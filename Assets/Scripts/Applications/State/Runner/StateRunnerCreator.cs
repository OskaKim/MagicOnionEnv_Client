namespace OskaKim.Applications.State.Runner
{
    public class StateRunnerCreator
    {
        public StateRunner Create(IState startState)
        {
            return new StateRunner(startState);
        }
    }
}
