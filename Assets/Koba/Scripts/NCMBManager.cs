using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class NCMBManager : MonoBehaviour
{
    public void Save(string name, float score)
    {
        NCMBObject ncmb = new NCMBObject("GameJam1025_Ranking");

        ncmb["PlayerName"] = name;
        ncmb["Score"] = score;

        ncmb.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e.ErrorMessage);
            }
            else
            {
                Debug.Log("Save Successful");
            }
        });
    }


    //public float[] Load()
    //{
    //    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("GameJam1025_Ranking");

    //    query.OrderByDescending("Score");
    //    query.Limit = 5;

        
    //}
    //}
}
