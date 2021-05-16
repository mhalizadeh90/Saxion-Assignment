using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    const int MainMenuSceneIndex = 0;
    int currentLevelIndex;
    void Awake()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void BackToMainMenu()
    {
        UnfreezeTimeScale();
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void RestartLevel()
    {
        UnfreezeTimeScale();
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void ContiniuLevel()
    {
        SceneManager.LoadScene(currentLevelIndex+1);
    }

    public void FreezeTimeScale()
    {
        Time.timeScale = 0;
    }

    public void UnfreezeTimeScale()
    {
        Time.timeScale = 1;
    }

}
