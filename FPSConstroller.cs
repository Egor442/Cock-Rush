using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSConstroller : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = -1;
    }
}