using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _indexScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_indexScene);
    }
}