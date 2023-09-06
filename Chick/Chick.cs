using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ChickMover))]
[RequireComponent(typeof(ChickAnimator))]
public class Chick : MonoBehaviour
{
    private IChickMover _mover;
    private IChickAnimator _animator;
    private bool _isReached;

    public event UnityAction Reached;

    public void Initialize()
    {
        _mover = GetComponent<ChickMover>();
        _animator = GetComponent<ChickAnimator>();
    }

    private void FixedUpdate()
    {
        if (_isReached)
            _mover.Follow();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isReached)
            return;

        if (collision.collider.TryGetComponent(out Player player))
        {
            _isReached = true;
            _animator.Run();
            Reached?.Invoke();
        }
    }
}