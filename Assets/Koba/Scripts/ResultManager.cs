using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_rankingText;
    [SerializeField] InputField m_nameInput;
    [SerializeField] RectTransform m_entryPanel;
    [SerializeField] GameObject m_inputPanel;
    [SerializeField] Text m_announceText;
    [SerializeField] float m_gracePeriod = 10f;
    [SerializeField] SceneChanger m_sceneChanger;

    List<NCMBObject> m_ranking;
    int m_score;
    float m_timer;
    bool m_closable = false;

    void Start()
    {
        m_scoreText.text = GameManager.Instance().ResultScore.ToString();
        int set = (int)GameManager.Instance().ResultScore;
        m_closable = false;

        //MakeRankingText();
        GetRanking(set);
    }

    void Update()
    {
        //if (!m_closable)
        //{
        //    m_timer += Time.deltaTime;

        //    if (m_timer > m_gracePeriod)
        //    {
        //        m_closable = true;
        //    }
        //}

        // m_announceText.color = GetAlphaColor(m_announceText.color);

        //if (Input.GetButtonDown("Jump") && !m_inputPanel.activeSelf)
        //{
        //    m_sceneChanger.ChangeScene();
        //}
    }


    public void GetRanking(int score)
    {
        m_score = score;

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("GameJam1025_Ranking");
        query.OrderByDescending("Score");
        query.Limit = 5;

        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e.ToString());
            }
            else
            {

                m_ranking = objList;
                MakeRankingText();

                if ((score > 0 && m_ranking.Count < 5) || score > int.Parse(m_ranking[m_ranking.Count - 1]["Score"].ToString()) || m_ranking.Count == 0)
                {
                    if (!m_closable)
                    {
                        m_inputPanel.SetActive(true);
                    }
                }
            }
        });
    }


    void MakeRankingText()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        for (int i = 0; i < m_ranking.Count; i++)
        {
            builder.Append((i + 1).ToString());
            builder.Append(", ");
            builder.Append(m_ranking[i]["PlayerName"].ToString());
            builder.Append(" : ");
            builder.AppendLine(m_ranking[i]["Score"].ToString());
        }
        Debug.Log("Ranking Text:\r\n" + builder.ToString());
        m_rankingText.text = builder.ToString();
    }

    public void SetScoreOfCurrentPlay(int score)
    {
        GetRanking(score);
    }

    public void Save()
    {
        NCMBObject ncmb = new NCMBObject("GameJam1025_Ranking");

        ncmb["PlayerName"] = m_nameInput.text; ;
        ncmb["Score"] = m_score;

        ncmb.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e.ErrorMessage);
            }
            else
            {
                Debug.Log("Save Successful");
                GetRanking(m_score);
            }
        });
    }

    private Color GetAlphaColor(Color c)
    {
        m_timer += Time.deltaTime * 3.0f;
        c.a = Mathf.Sin(m_timer) * 6.0f;

        return c;
    }

    public void OnEnter()
    {
        if (m_nameInput.text != "")
        {
            Save();
            m_inputPanel.SetActive(false);
            m_closable = true;
        }
    }
}
