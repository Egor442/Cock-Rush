using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public event UnityAction Encountered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Encountered?.Invoke();
    }
}