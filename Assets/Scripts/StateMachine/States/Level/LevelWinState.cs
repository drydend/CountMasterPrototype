using System;

public class LevelWinState : BaseState
{
    private LevelWinScrene _winScrene;
    private LevelUI _levelUI;
    public LevelWinState(LevelWinScrene winScrene, LevelUI levelUI)
    {
        _winScrene = winScrene;
        _levelUI = levelUI;
    }

    public override void Enter()
    {
        _levelUI.Disable();
        _winScrene.ShowWithDelay();
    }

    public override void Exit()
    {

    }
}
