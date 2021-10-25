using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    public void OnClick()
    {
        AudioSource source = FindObjectOfType<AudioSource>();
        source.PlayOneShot(_clip);
    }
}
