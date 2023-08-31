using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLoser : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private Obstacle[] _obstacles;

    public event UnityAction Losing;

    public void Lose()
    {
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