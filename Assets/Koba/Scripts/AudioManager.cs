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
            SetBGM();
            DontDestroyOnLoad(this);
        }
    }

    public void SetBGM()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (GameManager.Instance().CurrentType == BGMType.Title)
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[0];
            m_audioSource.Play();
        }
        else if (GameManager.Instance().CurrentType == BGMType.Main)
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[1];
            m_audioSource.Play();
        }
        else if (GameManager.Instance().CurrentType == BGMType.Result)
        {
            m_audioSource.Stop();
            m_audioSource.clip = m_audioClips[2];
            m_audioSource.Play();
        }
    }
}
