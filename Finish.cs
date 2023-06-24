using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private Score _score;

    public event UnityAction Finished;
    public event UnityAction Losing;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (_score.CountCollectChicks != 0)
            {
                if (_score.CountCollectChicks == _score.ChickPoints.Length)
                    Finished?.Invoke();
                else
                    Losing?.Invoke();
            }
            else
            {
                Losing?.Invoke();
            }
        }
    }
}