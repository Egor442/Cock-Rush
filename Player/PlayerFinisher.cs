using UnityEngine;
using UnityEngine.Events;

public class PlayerFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _gameFinishDisplay;

    public event UnityAction Finished;

    public void Finish()
    {
        _gameFinishDisplay.SetActive(true);
        Finished?.Invoke();
    }
}