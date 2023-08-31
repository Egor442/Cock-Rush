using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _gameFinishDisplay;

    public event UnityAction Finished;
    
    private Animator _animator;
    private PlayerMover _mover;

    public void Initialized()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
    }

    public void Finish()
    {
        _mover.NullifySpeed();

        _animator.SetBool("Run", false);
        _animator.SetBool("Eat", true);

        _gameFinishDisplay.SetActive(true);
        Finished?.Invoke();
    }
}