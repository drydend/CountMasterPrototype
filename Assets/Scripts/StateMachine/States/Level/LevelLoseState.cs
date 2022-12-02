using System;
public class LevelLoseState : BaseState
{
    private GameOverScrene _gameOverScrene;
    private LevelUI _levelUI;

    public LevelLoseState(GameOverScrene gameOverScrene, LevelUI levelUI)
    {
        _gameOverScrene = gameOverScrene;
        _levelUI = levelUI;
    }

    public override void Enter()
    {
        _levelUI.Disable();
        _gameOverScrene.ShowWithDelay();
    }

    public override void Exit()
    {

    }
}
