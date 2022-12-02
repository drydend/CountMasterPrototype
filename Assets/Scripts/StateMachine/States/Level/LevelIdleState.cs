public class LevelIdleState : BaseState
{
    private Level _level;
    private ILevelStartTrigger _levelStarter;
    private StateMachine _stateMachine;
    public LevelIdleState(Level level,StateMachine stateMachine ,ILevelStartTrigger levelStarter)
    {
        _level = level;
        _stateMachine = stateMachine;
        _levelStarter = levelStarter;
    }

    public override void Enter()
    {
        _levelStarter.OnLevelStart += StartLevel;
    }

    public override void Exit()
    {
        _levelStarter.OnLevelStart -= StartLevel;
    }
    
    private void StartLevel()
    {
        _stateMachine.SwitchState<LevelRuningState>();
    }
}
