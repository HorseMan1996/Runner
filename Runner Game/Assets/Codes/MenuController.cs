using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    int maxLives = 3;

    public void LoadGameScene()
    {
        PlayerPrefs.SetInt("lives", maxLives);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
