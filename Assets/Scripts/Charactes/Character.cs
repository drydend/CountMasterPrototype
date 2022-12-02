using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float _movementSpeed;
    [SerializeField]
    protected Animator _animator;
    protected Transform _desiredPosition;

    protected Coroutine _movementCoroutine;

    public virtual void Initialize(Transform desiredPosition)
    {
        _desiredPosition = desiredPosition;
    }

    public void SetDesiredPosition(Transform desiredPosition)
    {
        _desiredPosition = desiredPosition;
    }

    public void StartMovingToDesiredPosition()
    {
        _movementCoroutine = StartCoroutine(MoveTowardsDesiredPosition());
    }

    public virtual void StopMovingToDesiredPosition()
    {
        if (_movementCoroutine == null)
        {
            return;
        }

        StopCoroutine(_movementCoroutine);
    }

    protected virtual IEnumerator MoveTowardsDesiredPosition()
    {
        while (true)
        {
            var newPosition = Vector3.MoveTowards(transform.position, _desiredPosition.position,
                _movementSpeed * Time.fixedDeltaTime);
            transform.position = newPosition;
            yield return new WaitForFixedUpdate();
        }
    }
}

