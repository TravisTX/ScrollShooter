using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameStates GameState;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
    }

    public void ChangeState(GameStates newState)
    {
        // reset
        float newTimeScale = 0;

        switch (newState)
        {
            case GameStates.StartScreen:
                Application.LoadLevel("StartScreen");
                break;
            case GameStates.Playing:
                newTimeScale = 1;
                break;
            case GameStates.Paused:
                break;
            case GameStates.RecapScreen:
                ResetGame();
                ChangeState(GameStates.Playing);
                return;
                break;
            case GameStates.SetttingsScreen:
                break;
        }
        GameState = newState;
        Time.timeScale = newTimeScale;
    }

    public void ResetGame()
    {
        Time.timeScale = 0;

        // reset everything

        Hero.Instance.transform.position = new Vector3(0, 0, 0);
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }


        Time.timeScale = 1;
    }

    public enum GameStates
    {
        StartScreen,
        Playing,
        Paused,
        RecapScreen,
        SetttingsScreen
    }
}
