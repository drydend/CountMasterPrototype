using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class LevelRuningState : BaseState
{
    private PlayerCrowdMover _crowdMover;
    private CameraFollower _cameraFollower;
    private Transform _desiredCameraPosition;
    private List<Security> _security;
    private LevelUI _levelUI;

    public LevelRuningState(PlayerCrowdMover crowdMover, List<Security> security,
        Transform desiredCameraPosition, CameraFollower cameraFollower, LevelUI levelUI)
    {   
        _levelUI = levelUI;
        _crowdMover = crowdMover;
        _security = security;
        _cameraFollower = cameraFollower;
        _desiredCameraPosition = desiredCameraPosition;
    }

    public override void Enter()
    {
        _levelUI.Show();
        _cameraFollower.SetFollowingPosition(_desiredCameraPosition);
        _crowdMover.StartRuning();
    }

    public override void Exit()
    {
        _crowdMover.StopRuning();
        foreach (var security in _security)
        {
            security.StopFollowingImmidiatly();
        }
    }


}
