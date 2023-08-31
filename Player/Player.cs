using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerFinisher))]
[RequireComponent(typeof(PlayerLoser))]
public class Player : MonoBehaviour
{
    [SerializeField] private Finish _finish;

    private PlayerMover _mover;
    private PlayerFinisher _finisher;
    private PlayerLoser _loser;

    public void Initialize()
    {
        _mover = GetComponent<PlayerMover>();
        _finisher = GetComponent<PlayerFinisher>();
        _loser = GetComponent<PlayerLoser>();
    }

    private void OnEnable()
    {
        _finish.Finished += Finish;
        _finish.Losing += Lose;
    }

    private void OnDisable()
    {
        _finish.Finished -= Finish;
        _finish.Losing -= Lose;
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    private void Finish()
    {
        _finisher.Finish();
    }

    private void Lose()
    {
        _loser.Lose();
    }
}