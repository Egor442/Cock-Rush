using UnityEngine;

public class FPSConstroller : MonoBehaviour
{
    [SerializeField] private int _maxFps;

    public void Initialize()
    {
        Application.targetFrameRate = _maxFps;
    }
}