using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string m_nextScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(m_nextScene);
    }
}
