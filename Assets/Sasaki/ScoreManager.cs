using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] float _setScore;
    [SerializeField] Text _scoreText;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        float score = _timer * _setScore;
        _scoreText.text = score.ToString("Score : 00000");

        GameManager.Instance().GetScore(score);
    }
}
