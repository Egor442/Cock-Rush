using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    [SerializeField] private PlayerFinisher _finisher;
    [SerializeField] private PlayerLoser _loser;

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void Finish()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Eat", true);
    }

    public void Lose()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Turn Head", true);
    }

    private void OnEnable() 
    {
        _finisher.Finished += Finish;
        _loser.Losing += Lose;
    }

    private void OnDisable() 
    {
        _finisher.Finished -= Finish;
        _loser.Losing += Lose;
    }    
}