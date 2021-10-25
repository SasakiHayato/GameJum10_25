using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlazeSytem : MonoBehaviour
{
    public bool Go { get; private set; } = false;
    int _glazePoint = 0;

    public GameObject Player { set { _player = value; } }
    GameObject _player;

    void Update()
    {
        transform.position = _player.transform.position;
    }

    void Set()
    {
        _glazePoint++;

        if (_glazePoint > 10) Go = true;
    }

    public void GoBom()
    {
        Go = false;
        _glazePoint = 0;
        GameObject[] get = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var item in get)
        {
            Destroy(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("触れた");
            Set();
        }
    }
}
