using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private FPSConstroller _fpsController;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Chick[] _chickPoints;
    [SerializeField] private ChickAnimator[] _chickAnimators;
    [SerializeField] private GameFinishDisplay _gameFinishDisplay;
    [SerializeField] private GameOverDisplay _gameOverDisplay;

    private void Awake()
    {
        _fpsController.Initialize();
        _player.Initialize();
        _playerMover.Initialize();
        _playerAnimator.Initialize();

        foreach (var chickPoint in _chickPoints)
            chickPoint.Initialize();

        foreach (var chickAnimators in _chickAnimators)
            chickAnimators.Initialize();

        _gameOverDisplay.Initialize();
        _gameFinishDisplay.Initialize();
    }
}