using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerFinisher))]
[RequireComponent(typeof(PlayerLoser))]
public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private Finish _finish;

    private IPlayerMover _playerMover;
    private IPlayerFinisher _playerFinisher;
    private IPlayerLoser _playerLoser;

    public void Initialize()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerFinisher = GetComponent<PlayerFinisher>();
        _playerLoser = GetComponent<PlayerLoser>();
    }

    public void Finish()
    {
        _playerFinisher.Finish();
    }

    public void Lose()
    {
        _playerLoser.Lose();
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
        _playerMover.Move();
    }   
}