using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonParent<GameManager>
{
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static GameManager instance = null;

    public enum GamePhases
    {
        StartPhase, PlayPhase
    }

    public GamePhases currentGamePhase = GamePhases.StartPhase;

    public void GoBackToLevelSelection()
    {
        SceneManager.LoadScene("StartPhase");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetNextPhase(GamePhases nextPhase)
    {
        EndCurrentPhaseBehavior();
        currentGamePhase = nextPhase;
        StartCurrentPhaseBehavior();
    }
    public void StartCurrentPhaseBehavior()
    {
        switch (currentGamePhase)
        {
            case GamePhases.StartPhase:
                break;

            case GamePhases.PlayPhase:
                SceneManager.LoadScene(1);
                break;
        }
    }
    public void EndCurrentPhaseBehavior()
    {
        switch (currentGamePhase)
        {
            case GamePhases.StartPhase:
                break;

            case GamePhases.PlayPhase:
                break;
        }
    }

    public void OnStartGamePressed()
    {
        SetNextPhase(GamePhases.PlayPhase);
    }

    public void OnPlayBackPressed()
    {
        SetNextPhase(GamePhases.StartPhase);
    }

    public void OnPlayQuitPressed()
    {
        SetNextPhase(GamePhases.StartPhase);
    }

    public void OnPaused()
    {
        Time.timeScale = 0f;
    }

    public void OnUnPaused()
    {
        Time.timeScale = 1f;
    }
}

