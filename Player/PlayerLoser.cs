using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerLoser : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private Obstacle[] _obstacles;

    private Animator _animator;
    private PlayerMover _mover;

    public event UnityAction Losing;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
    }

    public void Lose()
    {
        _mover.NullifySpeed();

        _animator.SetBool("Run", false);
        _animator.SetBool("Turn Head", true);

        _gameOverDisplay.SetActive(true);
        Losing?.Invoke();
    }

    private void OnEnable()
    {
        foreach (var obstacle in _obstacles)
            obstacle.Encountered += Lose;
    }

    private void OnDisable()
    {
        foreach (var obstacle in _obstacles)
            obstacle.Encountered -= Lose;
    }
}