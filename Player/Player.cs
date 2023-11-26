using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerFinisher))]
[RequireComponent(typeof(PlayerLoser))]
public class Player : MonoBehaviour
{
    [SerializeField] private Finish _finish;

    private PlayerMover _playerMover;
    private PlayerFinisher _playerFinisher;
    private PlayerLoser _playerLoser;

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