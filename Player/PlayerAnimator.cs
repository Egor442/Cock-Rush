using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    [SerializeField] private PlayerFinisher _playerFinisher;
    [SerializeField] private PlayerLoser _playerLoser;

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
        _playerFinisher.Finished += Finish;
        _playerLoser.Losing += Lose;
    }

    private void OnDisable() 
    {
        _playerFinisher.Finished -= Finish;
        _playerLoser.Losing += Lose;
    }    
}