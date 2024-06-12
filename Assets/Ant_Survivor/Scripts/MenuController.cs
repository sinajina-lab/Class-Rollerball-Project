using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void GoBackToLevelSelection()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.GoBackToLevelSelection();
        }
    }

    public void OnPlayQuitPressed()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.OnPlayQuitPressed();
        }
    }
    public void OnStartGamePressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStartGamePressed();
        }
    }

    public void TriggerPause(bool isPaused)
    {
        if(GameManager.instance != null)
        {
            if(isPaused)
            { TimeManager.Instance.PauseGame(true); }
            else
            {TimeManager.Instance.PauseGame(false); }
        }
    }
}
