using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    IsGame,
    Count,
    Died,

    None,
}

public class GameManager
{
    // シングルトン
    static GameManager _instance = new GameManager();
    public static GameManager Instance() => _instance;
    private GameManager() { }

    public float ResultScore { get => _score; }
    float _score;
    float _timer;

    public GameState CurrentState { get => _current; }
    GameState _current = GameState.None;

    public GameState ChangeGameState(GameState state) => _current = state;

    public float CurrentTime()
    {
        if (_current != GameState.IsGame) return _timer = 0;
        _timer += Time.deltaTime;
        
        return _timer;
    }
    public void Died()
    {
        GameObject[] games = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in games)
        {
            MonoBehaviour.Destroy(bullet);
        }

        UiManager ui = GameObject.FindObjectOfType<UiManager>();
        ui.Deadpanel();
    }

    public void GetScore(float set)
    {
        _score = set;
        Debug.Log(_score);
    }
}
