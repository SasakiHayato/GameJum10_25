using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // シングルトン
    static GameManager _instance = new GameManager();
    public static GameManager Instance() => _instance;
    private GameManager() { }

    public float ResultScore { get => _score; }
    float _score;

    public void Died()
    {
        
    }

    public float GetScore(float set) => _score = set;
}
