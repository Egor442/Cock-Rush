using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ChickAnimator : MonoBehaviour
{
    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.SetTrigger("Run");
    }
}