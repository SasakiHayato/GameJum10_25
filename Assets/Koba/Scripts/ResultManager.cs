using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_rankingText;
    [SerializeField] Text m_announceText;
    [SerializeField] SceneChanger m_sceneChanger;

    float[] m_ranking;
    float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        m_scoreText.text = GameManager.Instance().ResultScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        m_announceText.color = GetAlphaColor(m_announceText.color);

        if (Input.GetButtonDown("Jump"))
        {
            m_sceneChanger.ChangeScene();
        }
    }

    private Color GetAlphaColor(Color c)
    {
        m_timer += Time.deltaTime * 3.0f;
        c.a = Mathf.Sin(m_timer) * 6.0f;

        return c;
    }
}
