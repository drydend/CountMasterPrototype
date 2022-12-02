using System.Collections;
using UnityEngine;

public class PlayerCrowdMover : MonoBehaviour
{
    [SerializeField]
    private PlayerCrowd _crowd;
    [SerializeField]
    private PlayerInput _input;
    [SerializeField]
    private float _maxXDisplacement = 4f;
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _movingSpeed;


    private Coroutine _movementCoroutine;

    public void MovePlayerTo(Vector3 position)
    {
        if (_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
        }
        _movementCoroutine = StartCoroutine(MovePlayerToPosition(position));
    }

    public void StartRuning()
    {
        if (_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
        }

        _crowd.StartMoving();
        _movementCoroutine = StartCoroutine(Run());
    }

    public void StopRuning()
    {
        _crowd.StopMoving();
        StopCoroutine(_movementCoroutine);
    }

    private IEnumerator MovePlayerToPosition(Vector3 position)
    {
        while (true)
        {
            var deltaPosition = Vector3.MoveTowards(_crowd.transform.position, position, _movingSpeed * Time.fixedDeltaTime);
            _crowd.transform.position = deltaPosition;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator Run()
    {
        while (true)
        {
            var deltaPosition = _crowd.transform.position + new Vector3(_input.XDisplacement * Time.fixedDeltaTime,
                0, _forwardSpeed * Time.fixedDeltaTime);

            float maxPositiveDisplacement;
            float maxNegativeDisplacement;

            GetMaxDisplacement(out maxPositiveDisplacement, out maxNegativeDisplacement);

            bool isInRightBourder = deltaPosition.x < maxPositiveDisplacement;
            bool isInLeftBourder = deltaPosition.x > maxNegativeDisplacement;

            if ((isInRightBourder && isInLeftBourder)
                || (isInRightBourder && !isInLeftBourder && _input.XDisplacement > 0)
                || (!isInRightBourder && isInLeftBourder && _input.XDisplacement < 0))
            {
                _crowd.transform.position = deltaPosition;
            }
            else
            {
                deltaPosition.x = _crowd.transform.position.x;
                _crowd.transform.position = deltaPosition;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void GetMaxDisplacement(out float maxPositiveDisplacement, out float maxNegativeDisplacement)
    {
        maxPositiveDisplacement = _maxXDisplacement;
        maxNegativeDisplacement = -_maxXDisplacement;

        float mostNegativeX = 0f;
        float mostPositiveX = 0f;

        foreach (var runner in _crowd)
        {
            var difference = runner.transform.position.x - _crowd.transform.position.x;

            if (difference > mostPositiveX)
            {
                mostPositiveX = difference;
            }
            else if (difference < mostNegativeX)
            {
                mostNegativeX = difference;
            }
        }

        maxPositiveDisplacement -= mostPositiveX;
        maxNegativeDisplacement -= mostNegativeX;

    }
}
