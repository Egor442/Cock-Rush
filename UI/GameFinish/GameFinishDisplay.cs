using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class GameFinishDisplay : MonoBehaviour
{
    [SerializeField] private PlayerFinisher _playerFinisher;
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
        _playerFinisher.Finished += OnFinished;
        _restartButton.onClick.AddListener(OnRestartButtonOnClick);
        _nextLevelButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _playerFinisher.Finished -= OnFinished;
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