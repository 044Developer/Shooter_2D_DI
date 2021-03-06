using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const int GamePaused = 0;
    private const int GameResumed = 1;
    private const string MainMenuScene = "MainMenu";

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameEvents.ResumeGame += ResumeGame;
        GameEvents.PauseGame += PauseGame;
        SceneEvents.ReloadScene += ReloadScene;
        SceneEvents.LoadMainMenu += LoadMainMenu;
        SceneEvents.LoadLevelScene += LoadLevelScene;
    }

    private void Start()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = GamePaused;
    }

    private void ResumeGame()
    {
        Time.timeScale = GameResumed;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    private void LoadLevelScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerEvents.OnSaveProgressData();
    }

    private void OnApplicationQuit()
    {
        PlayerEvents.OnSaveProgressData();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        GameEvents.ResumeGame -= ResumeGame;
        GameEvents.PauseGame -= PauseGame;
        SceneEvents.ReloadScene -= ReloadScene;
        SceneEvents.LoadMainMenu -= LoadMainMenu;
        SceneEvents.LoadLevelScene -= LoadLevelScene;
    }
}
