using UnityEngine;

public class ChickMover : MonoBehaviour, IChickMover
{
    [SerializeField] private ChickData _data;
    [SerializeField] private Transform _target;

    private Vector3 _targetLastPosition;

    public void Follow()
    {
        if (_targetLastPosition != _target.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target.position, _data.Speed * Time.deltaTime);
            _targetLastPosition = _target.position;
        }
    }
}