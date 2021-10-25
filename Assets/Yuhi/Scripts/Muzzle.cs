using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    private enum Type
    {
        single,
        way
    }
    [SerializeField] Type m_type = Type.single;
    [SerializeField] float m_speed = 1f;
    private GameObject m_player;

    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (m_type == Type.single)
        {

        }
        else if (m_type == Type.way)
        {

        }
    }

    private void Single()
    {

    }

    private void Way()
    {

    }
}
