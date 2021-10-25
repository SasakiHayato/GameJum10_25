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

    Text _countText;
    float _countTime = 4;

    void Start()
    {
        _countPanel.SetActive(false);
    }

    void Update()
    {
        float time = GameManager.Instance().CurrentTime();
       
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
        _scoreText.text = score.ToString(_scoreText.text);
        
        GameManager.Instance().GetScore(score);
    }
}
