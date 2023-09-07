using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private PlayerLoser _playerLoser;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _gameOverGroup;

    public void Initialize()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _playerLoser.Losing += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonOnClick);
    }

    private void OnDisable()
    {
        _playerLoser.Losing -= OnDied;
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