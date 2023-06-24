using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseDisplay : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }

    private void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}