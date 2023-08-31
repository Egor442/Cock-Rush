using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigitBody;

    public void Initialize()
    {
        _rigitBody = GetComponent<Rigidbody>();
    }

    public void NullifySpeed()
    {
        _speed = 0;
        _stepSize = 0;
    }

    public void Move()
    {
        gameObject.transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        _rigitBody.velocity = new Vector3(_joystick.Horizontal * _stepSize, _rigitBody.velocity.y, _rigitBody.velocity.z);
    }    
}