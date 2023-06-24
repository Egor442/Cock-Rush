using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Chick : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private Vector3 _targetLastPosition;
    private Animator _animator;
    private bool _isReached;

    public event UnityAction Reached;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(_isReached)
        {
            if (_targetLastPosition != _target.position)
                Follow();
        }
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

    private void Follow()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target.position, _speed * Time.deltaTime);
        _targetLastPosition = _target.position;
    } 
}