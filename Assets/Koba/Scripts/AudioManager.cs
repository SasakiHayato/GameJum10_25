using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance = new AudioManager();

    [SerializeField] AudioSource m_audioSource;
    [SerializeField] AudioClip[] m_audioClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[0];
            m_audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[1];
            m_audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[2];
            m_audioSource.Play();
        }
    }
}
