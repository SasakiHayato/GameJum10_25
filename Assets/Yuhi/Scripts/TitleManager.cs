using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_rankingPanel;
    private List<NCMBObject> m_ranking;
    
    void Start()
    {
        GetRanking();
    }

    private void GetRanking()
    {
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
                ViewRanking();
                //if ((score > 0 && m_ranking.Count < 5) || score > int.Parse(m_ranking[m_ranking.Count - 1]["Score"].ToString()) || m_ranking.Count == 0)
                //{
                //    m_rankingPanel.gameObject.SetActive(true);
                //}
            }
        });
    }

    private void ViewRanking()
    {
        string text;
        for (int i = 0; i < m_ranking.Count; i++)
        {
            text = $"{m_ranking[i]["PlayerName"]} : {m_ranking[i]["Score"]}";
            m_rankingPanel.transform.GetChild(i).GetComponent<Text>().text = text;
        }
    }
}
