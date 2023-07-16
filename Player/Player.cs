using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private GameObject _gameFinishDisplay;
    [SerializeField] private Obstacle[] _obstacles;

    private Animator _animator;
    private PlayerMover _mover;

    public event UnityAction Losing;
    public event UnityAction Finished;   

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _finish.Finished += Finish;
        _finish.Losing += Lose;

        foreach (var obstacle in _obstacles)
            obstacle.Encountered += Lose;
    }

    private void OnDisable()
    {
        _finish.Finished -= Finish;
        _finish.Losing -= Lose;

        foreach (var obstacle in _obstacles)
            obstacle.Encountered -= Lose;
    }

    private void Finish()
    {
        _mover.NullifySpeed();

        _animator.SetBool("Run", false);
        _animator.SetBool("Eat", true);

        _gameFinishDisplay.SetActive(true);       
        Finished?.Invoke();
    }

    private void Lose()
    {
        _mover.NullifySpeed();

        _animator.SetBool("Run", false);
        _animator.SetBool("Turn Head", true);

        _gameOverDisplay.SetActive(true);
        Losing?.Invoke();
    }
}