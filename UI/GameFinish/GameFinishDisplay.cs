using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class GameFinishDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;

    private static int _indexCurrentScene;

    private CanvasGroup _gameOverGroup;

    public void Initialize()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _player.Finished += OnFinished;
        _restartButton.onClick.AddListener(OnRestartButtonOnClick);
        _nextLevelButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Finished -= OnFinished;
        _restartButton.onClick.RemoveListener(OnRestartButtonOnClick);
        _nextLevelButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void OnFinished()
    {
        _gameOverGroup.DOFade(1, 0.2f).SetEase(Ease.Linear);
    }

    private void OnRestartButtonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}