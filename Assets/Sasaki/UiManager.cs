using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] float _setScore;
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _opretions;
    [SerializeField] GameObject _countPanel;
    [SerializeField] GameObject _deadPanel;

    Text _countText;
    float _countTime = 4;
    float _score;
    string _scoreStr;

    bool _isSet = false;

    void Start()
    {
        _countPanel.SetActive(false);
        _deadPanel.SetActive(false);
        _scoreStr = _scoreText.text;
    }

    void Update()
    {
        CountDown();
        Score();
    }

    public void SetCountDown()
    {
        _opretions.SetActive(false);
        GameManager.Instance().ChangeGameState(GameState.Count);
        _countPanel.SetActive(true);
        _countText = _countPanel.transform.GetChild(0).GetComponent<Text>();
    }

    public void Deadpanel()
    {
        if (_isSet) return;
        _isSet = true;
        
        _deadPanel.SetActive(true);
        GameManager.Instance().GetScore(_score);
    }

    void CountDown()
    {
        if (GameManager.Instance().CurrentState == GameState.Count)
        {
            _countTime -= Time.deltaTime;
            _countText.text = _countTime.ToString();

            if (_countTime > 0 && _countTime < 1)
            {
                _countText.text = "Go";
            }

            if (_countTime < 0)
            {
                GameManager.Instance().ChangeGameState(GameState.IsGame);
                _countPanel.SetActive(false);
            }
        }
    }

    void Score()
    {
        float time = GameManager.Instance().CurrentTime();
        float score = time * _setScore;
        _scoreText.text = score.ToString(_scoreStr);
        _score = score;
    }
}
