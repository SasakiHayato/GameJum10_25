using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string m_nextScene;

    public void ChangeScene()
    {
        Fade.FadeOut(1);
        //Invoke("Load", 1);
        StartCoroutine(Set());
    }

    IEnumerator Set()
    {
        while (!Fade.IsFade)
        {
            yield return null;
        }
        Load();
    }

    void Load()
    {
        if (m_nextScene == "MainScene")
            GameManager.Instance().ChangeBGMType(BGMType.Main);
        else if (m_nextScene == "TitleScene")
            GameManager.Instance().ChangeBGMType(BGMType.Title);
        else if (m_nextScene == "ResultScene")
            GameManager.Instance().ChangeBGMType(BGMType.Result);

        SceneManager.LoadScene(m_nextScene);
        AudioManager audio = FindObjectOfType<AudioManager>();
        audio.SetBGM();
    }
}
