using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ChickMover))]
public class Chick : MonoBehaviour
{
    private Animator _animator;
    private ChickMover _mover;
    private bool _isReached;

    public event UnityAction Reached;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<ChickMover>();
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
            _animator.SetTrigger("Run");
            Reached?.Invoke();
        }
    }
}