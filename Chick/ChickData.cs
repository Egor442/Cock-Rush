using UnityEngine;

[CreateAssetMenu(fileName = "new Chick", menuName = "Chick", order = 51)]
public class ChickData : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}