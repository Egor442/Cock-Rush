using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _gameOverGroup;

    public void Initialize()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _player.Losing += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonOnClick);
    }

    private void OnDisable()
    {
        _player.Losing -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonOnClick);
    }

    private void OnDied()
    {
        _gameOverGroup.DOFade(1, 0.2f).SetEase(Ease.Linear);
    }

    private void OnRestartButtonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}