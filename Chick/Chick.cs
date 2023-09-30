using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ChickMover))]
[RequireComponent(typeof(ChickAnimator))]
public class Chick : MonoBehaviour
{
    private IChickMover _chickMover;
    private IChickAnimator _chickAnimator;
    private bool _isReached;

    public event UnityAction Reached;

    public void Initialize()
    {
        _chickMover = GetComponent<ChickMover>();
        _chickAnimator = GetComponent<ChickAnimator>();
    }

    private void FixedUpdate()
    {
        if (_isReached)
        {
            _chickMover.Follow();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isReached)
        {
            return;
        }

        if (collision.collider.TryGetComponent(out Player player))
        {
            _isReached = true;
            _chickAnimator.Run();
            Reached?.Invoke();
        }
    }
}