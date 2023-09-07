using UnityEngine;

public class Puase : MonoBehaviour
{
    [SerializeField] private GameObject _pauseDisplay;

    public void OnPauseButtonClick()
    {
        _pauseDisplay.SetActive(true);
        Time.timeScale = 0;
    }
}
