using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameFinishDisplay _gameFinishDisplay;
    [SerializeField] private GameOverDisplay _gameOverDisplay;

    private Chick[] _chickPoints;

    private void Awake()
    {
        _player.Initialize();
        _playerMover.Initialize();

        _chickPoints = FindObjectsOfType<Chick>();

        foreach (var chickPoint in _chickPoints)
            chickPoint.Initialize();

        _gameOverDisplay.Initialize();    
        _gameFinishDisplay.Initialize();   
    }
}