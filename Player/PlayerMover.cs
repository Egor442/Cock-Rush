using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerMover : MonoBehaviour, IPlayerMover
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerFinisher _playerFinisher;
    [SerializeField] private PlayerLoser _playerLoser;

    private Rigidbody _rigitBody;

    public void Initialize()
    {
        _rigitBody = GetComponent<Rigidbody>();
    }
   
    public void Move()
    {
        gameObject.transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        _rigitBody.velocity = new Vector3(_joystick.Horizontal * _stepSize, _rigitBody.velocity.y, _rigitBody.velocity.z);
    } 

    private void OnEnable() 
    {
        _playerFinisher.Finished += NullifySpeed;
        _playerLoser.Losing += NullifySpeed;
    }  

    private void OnDisable() 
    {
        _playerFinisher.Finished -= NullifySpeed;
        _playerLoser.Losing -= NullifySpeed;
    }

    private void NullifySpeed()
    {
        _speed = 0;
        _stepSize = 0;
    } 
}